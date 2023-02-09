using ECom.Application.Validators;
using ECom.Domain.Extensions;
using ECom.Domain.Results;

namespace ECom.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IEfEntityRepository<Admin> _adminRepo;
        private readonly IEfEntityRepository<RolePermission> _rolePermissionRepo;
        private readonly IEfEntityRepository<Permission> _permissionRepo;
        private readonly IOptionService _optionService;
        private readonly IValidationService _validationService;

        public AdminService(
            IEfEntityRepository<Admin> adminRepo,
            IEfEntityRepository<RolePermission> rolePermissionRepo,
            IEfEntityRepository<Permission> permissionRepo,
            IOptionService optionService,
            IValidationService validationService)
        {
            this._adminRepo = adminRepo;
            this._rolePermissionRepo = rolePermissionRepo;
            this._permissionRepo = permissionRepo;
            this._optionService = optionService;
            _validationService = validationService;
        }

       
     
    
        public ResultData<Admin> GetAdmin(string email)
        {
            var admin = _adminRepo
                .Get(x => x.EmailAddress == email && x.IsTestAccount == ConstantMgr.IsDebug() && !x.DeletedDate.HasValue && x.IsValid == true)
                .Include(x => x.Role)
                .ThenInclude(x => x.Permissions)
                .FirstOrDefault();
            if (admin is null)
            {
                return DomainResult.Admin.NotFoundResult(1);
            };
            if (!admin.Role.Permissions.Any())
            {
                return DomainResult.Admin.NotHavePermissionResult(2);
            }
            return admin;
        }
        public ResultData<Admin> GetAdmin(int id)
        {
            var admin = _adminRepo
                .Get(x => x.Id == id && x.IsTestAccount == ConstantMgr.IsDebug() && !x.DeletedDate.HasValue && x.IsValid == true)
                .Include(x => x.Role)
                .ThenInclude(x => x.Permissions)
                .FirstOrDefault();
            if (admin is null)
            {
                return DomainResult.Admin.NotFoundResult(1);
            };
            if (!admin.Role.Permissions.Any())
            {
                return DomainResult.Admin.NotHavePermissionResult(2);
            }
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
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
            }

            return DomainResult.Admin.AddSuccessResult();
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
                return DomainResult.Admin.NotFoundResult(1);
            }
            if (admin.Password != model.EncryptedOldPassword)
            {
                return DomainResult.Base.PasswordWrongResult(2);
            }
            admin.Password = model.EncryptedNewPassword;
            var res = _adminRepo.Update(admin);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(3);
            }
            return DomainResult.Admin.ChangePasswordSuccessResult();
        }

        public ResultData<Admin> Login(LoginRequestModel model)
        {
            var admin = _adminRepo
                .Get(x => x.EmailAddress == model.EmailAddress)
                .Include(x => x.Role)
                .ThenInclude(x => x.Permissions)
                .ThenInclude(x => x.Permission)
                .FirstOrDefault();
            if (admin is null)
            {
                return DomainResult.Admin.NotFoundResult(1);
            }
            if (admin.Password != model.EncryptedPassword)
            {
                //Todo log
                return DomainResult.Admin.NotFoundResult(2);
            }

            if (admin.Role.Permissions.Count == 0)
            {
                return DomainResult.Admin.NotHavePermissionResult(3);
            }
            var validator = new AdminValidator(_validationService);
            var validateResult = validator.Validate(admin);
            if (!validateResult.IsValid)
            {
                var first = validateResult.Errors.First();
                return DomainResult.ValidationErrorResult(4, first.PropertyName, first.ErrorCode);
            }
            if (admin.TwoFactorType != 0)
            {
                //TODO: two factor
            }
            //todo log
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

        public List<Admin> ListOtherAdmins(int adminId)
        {
            return _adminRepo
                .Get(x => x.IsTestAccount == ConstantMgr.IsDebug() && x.Id != adminId)
                .Include(x => x.Role)
                .ThenInclude(x => x.Permissions)
                .ToList();
        }

        public Result EnableOrDisableAdmin(int authorAdminId, int adminId)
        {
            //TODO: maybe check admin permissions here as well
            var admin = _adminRepo.Find(adminId);
            if (admin is null)
            {
                return DomainResult.Admin.NotFoundResult(1);
            }
            admin.IsValid = !admin.IsValid;
            var res = _adminRepo.Update(admin);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
            }

            return DomainResult.Admin.UpdateSuccessResult();
        }

        public Result DeleteAdmin(int authorAdminId, int adminId)
        {
            //TODO: maybe check admin permissions here as well
            var admin = _adminRepo.Find(adminId);
            if (admin is null)
            {
                return DomainResult.Admin.NotFoundResult(1);
            }

            if (admin.DeletedDate.HasValue)
            {
                return DomainResult.Admin.DeletedResult(2);
            }
            admin.DeletedDate = DateTime.Now;
            var res = _adminRepo.Update(admin);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
            }

            return DomainResult.Admin.DeleteSuccessResult();
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
