

using ECom.Infrastructure.DependencyResolvers.AspNetCore;

namespace ECom.Infrastructure.Services
{
	public interface IAdminService : IEfEntityRepository<Admin>
	{
		Admin? GetAdmin(string email);
		bool HasPermission(int adminId, int permissionId);
		bool IncreaseFailedPasswordCount(Admin admin);
		ResultData<Admin> Login(LoginModel model);
		bool UpdateSuccessLogin(Admin admin);
	}

	public class AdminService : EfEntityRepositoryBase<Admin, EComDbContext>, IAdminService
	{
		public bool HasPermission(int adminId, int permissionId)
		{
			var service = ServiceProviderProxy.GetService<IRoleBindService>();
			var ctx = new EComDbContext();
			var admin = GetSingle(x => x.Id == adminId && x.IsValid == true && x.IsEmailVerified == true && x.DeletedDate != null);
			if (admin.RoleId is null) throw new BaseException(Response.DbErrorForeignKeyIsInvalid);
			return service.Any(x => x.PermissionId == permissionId && x.RoleId == admin.RoleId && x.IsValid == true);
		}
		public ResultData<Admin> Login(LoginModel model)
		{
			var validateResult = LoginValidator.This.Validate(model);
			if (!validateResult.IsValid)
			{
				return ResultData<Admin>.Error(1, validateResult.Errors.First().ErrorCode.ToResponseEnum());
			}
			var admin = GetAdmin(model.EmailAddress);
			if (admin is null)
			{
				return ResultData<Admin>.Error(2, Response.AccountNotFound);
			}
			var hashed = model.Password.MD5Hash().ConvertToString();
			if (admin.Password != hashed)
			{
				IncreaseFailedPasswordCount(admin);
				return ResultData<Admin>.Error(3, Response.AccountNotFound);
			}
			var validateResult2 = AdminValidator.This.Validate(admin);
			if (!validateResult2.IsValid)
			{
				return ResultData<Admin>.Error(4, validateResult.Errors.First().ErrorCode.ToResponseEnum());
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
			return GetFirst(x => x.EmailAddress == email);
		}
	}
}
