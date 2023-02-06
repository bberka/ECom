





using EasMe;
using EasMe.Helpers;
using ECom.Application.Validators;
using ECom.Domain.Abstract;
using ECom.Domain.ApiModels.Request;
using ECom.Domain.Extensions;
using ECom.Domain.Lib;
using System.Linq;

namespace ECom.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IEfEntityRepository<Admin> _adminRepo;
        private readonly IEfEntityRepository<RolePermission> _rolePermissionRepo;
        private readonly IEfEntityRepository<Permission> _permissionRepo;
        private readonly IOptionService _optionService;
        private readonly IValidationDbService _validationDbService;

        public AdminService(
            IEfEntityRepository<Admin> adminRepo,
            IEfEntityRepository<RolePermission> rolePermissionRepo,
            IEfEntityRepository<Permission> permissionRepo,
            IOptionService optionService,
            IValidationDbService validationDbService)
        {
            this._adminRepo = adminRepo;
            this._rolePermissionRepo = rolePermissionRepo;
            this._permissionRepo = permissionRepo;
            this._optionService = optionService;
            this._validationDbService = validationDbService;
        }

       
        public bool UpdateSuccessLogin(Admin admin)
        {
            var req = HttpContextHelper.Current.GetNecessaryRequestData();
            if (req == null) return false;
            admin.TotalLoginCount++;
            admin.LastLoginDate = DateTime.Now;
            admin.LastLoginIp = req.IpAddress;
            admin.LastLoginUserAgent = req.UserAgent;
            return _adminRepo.Update(admin);
        }
        public bool IncreaseFailedPasswordCount(Admin admin)
        {
            admin.FailedPasswordCount++;
            return _adminRepo.Update(admin);
        }
        public Admin? GetAdmin(string email)
        {
            
            var admin = _adminRepo
                .Get(x => x.EmailAddress == email && x.IsTestAccount == ConstantMgr.IsDebug() && !x.DeletedDate.HasValue && x.IsValid == true)
                .Include(x => x.Role)
                .FirstOrDefault();
            if (admin is null) return null;
            admin.Permissions = _rolePermissionRepo
                .Get(x => x.RoleId == admin.RoleId)
                .Include(x => x.Permission)
                .Select(x=> x.Permission)
                .ToList();
            return admin;
        }
        public bool HasPermission(int adminId, int permissionId)
        {
            var isValid = IsValidPermission(permissionId);
            if(!isValid) return false;
           
            var roleId = _adminRepo
                .Get(x => x.Id == adminId && x.IsTestAccount == ConstantMgr.IsDebug() && !x.DeletedDate.HasValue && x.IsValid == true)
                .Include(x => x.Role)
                .Select(x => x.RoleId)
                .FirstOrDefault(0);
            if (roleId == 0) return false;
            return _rolePermissionRepo.Any(x => x.RoleId == roleId && x.PermissionId == permissionId);
        }

        public Admin? GetAdmin(int id)
        {
      
            var admin = _adminRepo
                .Get(x => x.Id == id && x.IsTestAccount == ConstantMgr.IsDebug() && !x.DeletedDate.HasValue && x.IsValid == true)
                .Include(x => x.Role)
                .FirstOrDefault();
            if (admin is null) return null;
            admin.Permissions = _rolePermissionRepo
                .Get(x => x.RoleId == admin.RoleId)
                .Include(x => x.Permission)
                .Select(x => x.Permission)
                .ToList();
            return admin;
        }

        public bool IsValidAdminAccount(int id)
        {
            return _adminRepo.Any(x => x.Id == id && x.IsTestAccount == ConstantMgr.IsDebug() && !x.DeletedDate.HasValue && x.IsValid == true);
        }

        public bool Exists(int id)
        {
            return _adminRepo.Any(x => x.Id == id);
        }

        public bool Exists(string email)
        {
            return _adminRepo.Any(x => x.EmailAddress == email);
        }

        public List<Admin> GetAdmins()
        {
            return _adminRepo.GetList();
        }

        public Result AddAdmin(AddAdminRequestModel admin)
        {
            var res = _adminRepo.Add(admin.ToAdminEntity());
            if (!res) {
                return Result.DbInternal(1);
            }
            return Result.Success(nameof(Admin));
        }

        public int GetAdminRoleId(int adminId)
        {
            return _adminRepo
                .Get(x => x.Id == adminId && x.IsValid == true && x.IsTestAccount == ConstantMgr.IsDebug() && !x.DeletedDate.HasValue)
                .Select(x => x.RoleId)
                .FirstOrDefault(0);
        }

    

        public Result ChangePassword(ChangePasswordRequestModel model)
        {
            var admin = _adminRepo.Find(model.AuthenticatedAdminId);
            if(admin is null)
            {
                return Result.Error(1, ErrorCode.NotFound, nameof(Admin));
            }
            if (admin.Password != model.EncryptedOldPassword)
            {
                return Result.Warn(2, ErrorCode.NotMatch, "RealPassword", "OldPassword");
            }
            admin.Password = model.EncryptedNewPassword;
            var res = _adminRepo.Update(admin);
            if (!res)
            {
                return Result.DbInternal(3);
            }
            return Result.Success();
        }

        public ResultData<Admin> Login(LoginRequestModel model)
        {
            var admin = GetAdmin(model.EmailAddress);
            if (admin is null) return ResultData<Admin>.Warn(1, ErrorCode.NotFound,nameof(Admin));
            var hashed = Convert.ToBase64String(model.Password.MD5Hash());
            if (admin.Password != hashed)
            {
                IncreaseFailedPasswordCount(admin);
                if (admin is null) return ResultData<Admin>.Warn(2, ErrorCode.NotFound, nameof(Admin));
            }
            var validator = new AdminValidator(_validationDbService);
            var validateResult = validator.Validate(admin);
            if (!validateResult.IsValid)
            {
                var first = validateResult.Errors.First();
                if (admin is null) return ResultData<Admin>.Warn(3, ErrorCode.ValidationError, nameof(Admin), first.PropertyName, first.ErrorCode);
            }
            if (admin.TwoFactorType != 0)
            {
                //TODO: two factor
            }
            UpdateSuccessLogin(admin);
            
            return admin;
        }

        public List<Permission> GetValidPermissions()
        {
            return _permissionRepo.GetList(x => x.IsValid == true);
        }

        public List<Permission> GetInvalidPermissions()
        {
            return _permissionRepo.GetList(x => x.IsValid == false);
        }

        public bool IsValidPermission(int permissionId)
        {
            return _permissionRepo.Any(x => x.IsValid == true && x.Id == permissionId);
        }

        public List<Permission> GetPermissions(int adminId)
        {
            var roleId = GetAdminRoleId(adminId);
            if (roleId < 1) return new();
            var invalidPerms = GetInvalidPermissions().Select(x => x.Id).ToList();
            return _rolePermissionRepo
                .Get(x => x.RoleId == roleId && !invalidPerms.Contains(x.PermissionId))
                .Include(x => x.Permission)
                .Select(x => x.Permission)
                .ToList();
        }
    }
}
