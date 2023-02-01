using EasMe;
using EasMe.Extensions;
using ECom.Application.Validators;
using ECom.Domain.Entities;
using ECom.Domain.Extensions;
using ECom.Infrastructure.Abstract;

namespace ECom.Application.BaseManager
{
	public class UserMgr : EfEntityRepositoryBase<User, EComDbContext>
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

		public Result Register(RegisterModel model)
		{
			var validateResult = RegisterValidator.This.Validate(model);
			if (!validateResult.IsValid)
			{
				return Result.Error(1, validateResult.Errors.First().ErrorCode.ToResponseEnum());
			}
			var user = model.ToUserEntity();
			var res = Add(user);
			if (res == false) return Result.Error(1, Response.DbErrorInternal);
			return Result.Success();
		}
		public ResultData<User> Login(LoginModel model)
		{
			var user = GetUser(model.Username);
			if (user is null)
			{
				return ResultData<User>.Error(1, Response.WrongUsernameOrPassword);
			}
			if (user.IsValid == true)
			{
				return ResultData<User>.Error(2, Response.AccountIsNotValid);
			}
			if (user.DeletedDate != null)
			{
				return ResultData<User>.Error(3, Response.AccountDeleted);
			}
			if (OptionMgr.This.GetSingle().IsDebug == false && user.IsTestAccount == true)
			{
				throw new BaseException(Response.AdminDebugAccountCanNotBeUsed);
			}
			var hashed = model.Password.MD5Hash().ConvertToString();
			if (user.Password != hashed)
			{
				IncreaseFailedPasswordCount(user);
				return ResultData<User>.Error(4, Response.WrongUsernameOrPassword);
			}
			if (user.IsEmailVerified == false)
			{
				return ResultData<User>.Error(5, Response.EmailIsNotVerified);
			}
			if (user.TwoFactorType != 0)
			{
				//TODO
			}
			UpdateSuccessLogin(user);
			return ResultData<User>.Success(user);
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
		public bool IncreaseFailedPasswordCount(int userId)
		{
			var res = UpdateSingleOrDefault(x => x.Id == userId, x => x.FailedPasswordCount++);
			return res;
		}
		public User? GetUser(string username)
		{
			var user = GetFirstOrDefault(x => x.Username == username);
			return user;
		}
		public User GetUserSingle(string username)
		{
			var user = GetSingle(x => x.Username == username);
			return user;
		}
		public void CheckUserExist(int userId)
		{
			var exist = Any(x => x.Id == userId);
			if (!exist) throw new BaseException(Response.UserNotExist);
		}
		public bool NotExistUsername(string username)
		{
			return !Any(x => x.Username == username);
		}
		public bool NotExistEmail(string username)
		{
			return !Any(x => x.Username == username);
		}
	}
}
