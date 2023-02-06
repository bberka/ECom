





using EasMe.Helpers;
using ECom.Application.Validators;
using ECom.Domain.ApiModels.Request;
using ECom.Domain.Extensions;
using ECom.Domain.Lib;

namespace ECom.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IEfEntityRepository<Admin> _adminRepo;
        private readonly IEfEntityRepository<RolePermission> _roleBindRepo;
        private readonly IOptionService _optionService;
        private readonly IValidationDbService _validationDbService;

        public AdminService(
            IEfEntityRepository<Admin> adminRepo,
            IEfEntityRepository<RolePermission> roleBindRepo,
            IOptionService optionService,
            IValidationDbService validationDbService)
        {
            this._adminRepo = adminRepo;
            this._roleBindRepo = roleBindRepo;
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
            var ctx = new EComDbContext();
            ctx.Update(admin);
            return ctx.SaveChanges() == 1;
        }
        public bool IncreaseFailedPasswordCount(Admin admin)
        {
            admin.FailedPasswordCount++;
            return _adminRepo.Update(admin);
        }
        public Admin? GetAdmin(string email)
        {
            return _adminRepo.GetFirstOrDefault(x => x.EmailAddress == email);
        }

        public Admin? GetAdmin(int id)
        {
            return _adminRepo.Find(id);
        }

        public Admin GetAdminOrThrow(int id)
        {
            var admin = GetAdmin(id);
            if (admin is null) throw new NotFoundException(nameof(Admin));
            return admin;
        }
        public Admin GetValidAdminOrThrow(int id)
        {
            var isTestAccount = false;
#if DEBUG
            isTestAccount = true;
#endif
            var admin = _adminRepo.GetFirstOrDefault(x => x.Id == id && x.IsTestAccount == isTestAccount && !x.DeletedDate.HasValue);
            if (admin is null) throw new NotFoundException(nameof(Admin));
            return admin;
        }

        public void CheckValidAdminOrThrow(int id)
        {
            var isTestAccount = false;
#if DEBUG
            isTestAccount = true;
#endif
            var admin = _adminRepo.Any(x => x.Id == id && x.IsTestAccount == isTestAccount && !x.DeletedDate.HasValue);
            if (!admin) throw new NotFoundException(nameof(Admin));
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
            if (!res) return Result.DbInternal(1);
            return Result.Success(nameof(Admin));
        }

        public int GetAdminRoleId(int adminId)
        {
            return _adminRepo.Get(x => x.Id == adminId).Select(x => x.RoleId).FirstOrDefault();
        }

    

        public Result ChangePassword(ChangePasswordRequestModel model)
        {
            var admin = GetAdminOrThrow(model.AuthenticatedAdminId);
            if (admin.Password != model.EncryptedOldPassword) return Result.Warn(1, ErrorCode.NotMatch, "RealPassword","OldPassword");
            admin.Password = model.EncryptedNewPassword;
            var res = _adminRepo.Update(admin);
            if (!res) return Result.DbInternal(2);
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
    }
}
