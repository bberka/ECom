





using EasMe.Helpers;
using ECom.Application.Validators;
using ECom.Domain.Extensions;
using ECom.Domain.Lib;

namespace ECom.Application.Services
{
	public interface IAdminService 
	{
		List<Admin> GetAdmins();
		Admin? GetAdmin(int id);
		Admin GetAdminSingle(int id);
		bool Exists(int id);
		bool Exists(string email);
		Admin? GetAdmin(string email);
		bool HasPermission(int adminId, int permissionId);
		bool IncreaseFailedPasswordCount(Admin admin);
		ResultData<Admin> Login(LoginModel model);
		bool UpdateSuccessLogin(Admin admin);
		Result AddAdmin(Admin admin);
	}

	public class AdminService : IAdminService
	{
		private readonly IEfEntityRepository<Admin> _adminRepo;
		private readonly IEfEntityRepository<RoleBind> _roleBindRepo;
		private readonly IOptionService _optionService;

		public AdminService(
			IEfEntityRepository<Admin> adminRepo, 
			IEfEntityRepository<RoleBind> roleBindRepo,
			IOptionService optionService)
		{
			this._adminRepo = adminRepo;
			this._roleBindRepo = roleBindRepo;
			this._optionService = optionService;
		}
		public bool HasPermission(int adminId, int permissionId)
		{
			var ctx = new EComDbContext();
			var admin = _adminRepo.GetSingle(x => x.Id == adminId && x.IsValid == true && x.IsEmailVerified == true && x.DeletedDate != null);
			if (admin.RoleId is null) throw new BaseException("DbErrorInternal:ForeignKey");
			return _roleBindRepo.Any(x => x.PermissionId == permissionId && x.RoleId == admin.RoleId && x.IsValid == true);
		}
		public ResultData<Admin> Login(LoginModel model)
		{
			var admin = GetAdmin(model.EmailAddress);
			if (admin is null)
			{
				return ResultData<Admin>.Error(2, ErrCode.NotFound);
			}
			var hashed = model.Password.MD5Hash().ConvertToString();
			if (admin.Password != hashed)
			{
				IncreaseFailedPasswordCount(admin);
				return ResultData<Admin>.Error(3, ErrCode.NotFound);
			}
			var validator = new AdminValidator(_optionService);
			var validateResult = validator.Validate(admin);
			if (!validateResult.IsValid)
			{
				return ResultData<Admin>.Error(4, validateResult.Errors.First().ErrorCode);
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
			var ctx = new EComDbContext();
			admin.FailedPasswordCount++;
			ctx.Update(admin);
			return ctx.SaveChanges() == 1;
		}
		public Admin? GetAdmin(string email)
		{
			return _adminRepo.GetFirst(x => x.EmailAddress == email);
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

		public Result AddAdmin(Admin admin)
		{
			var res = _adminRepo.Add(admin);
			if (!res) return Result.Error(1, ErrCode.DbErrorInternal);
			return Result.Success("Updated");
		}
	}
}
