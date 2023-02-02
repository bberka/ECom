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
			if (res == false) return Result.Error(2, Response.DbErrorInternal);
			return Result.Success();
		}
		public ResultData<User> Login(LoginModel model)
		{
			var validateResult = LoginValidator.This.Validate(model);
			if (!validateResult.IsValid)
			{
				return ResultData<User>.Error(1, validateResult.Errors.First().ErrorCode.ToResponseEnum());
			}
			var user = GetUser(model.EmailAddress);
			if (user is null)
			{
				return ResultData<User>.Error(2, Response.AccountNotFound);
			}
			var hashed = model.Password.MD5Hash().ConvertToString();
			if (user.Password != hashed)
			{
				IncreaseFailedPasswordCount(user);
				return ResultData<User>.Error(3, Response.AccountNotFound);
			}
			var validateResult2 = UserValidator.This.Validate(user);
			if (!validateResult2.IsValid)
			{
				return ResultData<User>.Error(4, validateResult.Errors.First().ErrorCode.ToResponseEnum());
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
			var res = UpdateWhereSingle(x => x.Id == userId, x => x.FailedPasswordCount++);
			return res;
		}
		public User? GetUser(string email)
		{
			var user = GetFirstOrDefault(x => x.EmailAddress == email);
			return user;
		}
		public User GetUserSingle(string email)
		{
			var user = GetSingle(x => x.EmailAddress == email);
			return user;
		}
		public void CheckExists(int id)
		{
			var exist = Any(x => x.Id == id);
			if (!exist) throw new BaseException(Response.UserNotExist);
		}
		public void CheckExists(uint id)
		{
			var exist = Any(x => x.Id == id);
			if (!exist) throw new BaseException(Response.UserNotExist);
		}
	}
}
