





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
		private readonly IEfEntityRepository<RoleBind> _roleBindRepo;
		private readonly IOptionService _optionService;
		private readonly IValidationDbService _validationDbService;

		public AdminService(
			IEfEntityRepository<Admin> adminRepo, 
			IEfEntityRepository<RoleBind> roleBindRepo,
			IOptionService optionService,
			IValidationDbService validationDbService)
		{
			this._adminRepo = adminRepo;
			this._roleBindRepo = roleBindRepo;
			this._optionService = optionService;
			this._validationDbService = validationDbService;
		}
		public bool HasPermission(int adminId, int permissionId)
		{
			var ctx = new EComDbContext();
			var admin = _adminRepo.GetSingle(x => x.Id == adminId && x.IsValid == true && x.IsEmailVerified == true && x.DeletedDate != null);
			if (admin.RoleId is null) throw new DbInternalException("InvalidForeignKey");
			return _roleBindRepo.Any(x => x.PermissionId == permissionId && x.RoleId == admin.RoleId && x.IsValid == true);
		}
		public ResultData<Admin> Login(LoginRequestModel model)
		{
			var admin = GetAdmin(model.EmailAddress);
			if (admin is null) throw new NotFoundException(nameof(Admin));
			var hashed = Convert.ToBase64String(model.Password.MD5Hash());
			if (admin.Password != hashed)
			{
				IncreaseFailedPasswordCount(admin);
				throw new NotFoundException(nameof(Admin));
			}
			var validator = new AdminValidator(_validationDbService);
			var validateResult = validator.Validate(admin);
			if (!validateResult.IsValid)
			{
				return ResultData<Admin>.Error(3, validateResult.Errors.First().ErrorCode);
			}
			if (admin.TwoFactorType != 0)
			{
				//TODO
			}
			UpdateSuccessLogin(admin);
			return ResultData<Admin>.Success(admin);
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

		public Admin GetAdminSingle(int id)
		{
			return _adminRepo.GetSingle(x => x.Id == id);
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
			if (!res) throw new DbInternalException(nameof(AddAdmin));
			return Result.Success("Updated");
		}
	}
}
