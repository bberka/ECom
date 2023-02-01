using EasMe;
using EasMe.Extensions;
using ECom.Domain.Entities;
using ECom.Domain.Extensions;
using ECom.Infrastructure.Abstract;

namespace ECom.Application.BaseManager
{
	public class UserMgr : EfEntityRepositoryBase<User, EComDbContext>, IUserMgr
	{

		private UserMgr() { }
		public static UserMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static UserMgr? Instance;

	
		public ResultData<User> Login(LoginModel model)
		{
			var ctx = new EComDbContext();
			var admin = ctx.Users.Where(x => x.Username == model.Username).SingleOrDefault();
			if (admin is null)
			{
				return ResultData<User>.Error(1, Response.WrongUsernameOrPassword);
			}
			if (admin.IsValid == true)
			{
				return ResultData<User>.Error(2, Response.AccountIsNotValid);
			}
			if (admin.DeletedDate != null)
			{
				return ResultData<User>.Error(3, Response.AccountDeleted);
			}
			if (OptionMgr.This.GetSingle().IsDebug == false && admin.IsTestAccount == true)
			{
				throw new BaseException(Response.AdminDebugAccountCanNotBeUsed);
			}
			var hashed = model.Password.MD5Hash().ConvertToString();
			if (admin.Password != hashed)
			{
				IncreaseFailedPasswordCount(admin);
				return ResultData<User>.Error(4, Response.WrongUsernameOrPassword);
			}
			if (admin.IsEmailVerified == false)
			{
				return ResultData<User>.Error(5, Response.EmailIsNotVerified);
			}
			if (admin.TwoFactorType != 0)
			{
				//TODO
			}
			UpdateSuccessLogin(admin);
			return ResultData<User>.Success(admin);
		}
		
		public bool UpdateSuccessLogin(User user)
		{
			var req = HttpContextHelper.Current.GetNecessaryRequestData();
			user.TotalLoginCount++;
			user.LastLoginDate = DateTime.Now;
			user.LastLoginIp = req.IpAddress;
			user.LastLoginUserAgent = req.UserAgent;
			var ctx = new EComDbContext();
			ctx.Update(user);
			return ctx.SaveChanges() == 1;
		}

		public bool IncreaseFailedPasswordCount(User user)
		{
			var ctx = new EComDbContext();
			user.FailedPasswordCount++;
			ctx.Update(user);
			return ctx.SaveChanges() == 1;
		}
	}
}
