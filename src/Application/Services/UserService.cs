




using ECom.Application.Validators;
using ECom.Domain.Extensions;

namespace ECom.Application.Services
{
	public interface IUserService : IEfEntityRepository<User>
	{
		void CheckExists(int id);
		void CheckExists(uint id);
		User? GetUser(string email);
		User GetUserSingle(string email);
		bool IncreaseFailedPasswordCount(int userId);
		bool IncreaseFailedPasswordCount(User user);
		ResultData<User> Login(LoginModel model);
		Result Register(RegisterModel model);
		bool UpdateSuccessLogin(User user);
	}

	public class UserService : EfEntityRepositoryBase<User, EComDbContext>, IUserService
	{
		private readonly IOptionService optionService;

		public UserService(IOptionService optionService)
		{
			this.optionService = optionService;
		}
		public Result Register(RegisterModel model)
		{
			var user = model.ToUserEntity();
			var res = Add(user);
			if (res == false) return Result.Error(2, ErrCode.DbErrorInternal);
			return Result.Success();
		}
		public ResultData<User> Login(LoginModel model)
		{
			var user = GetUser(model.EmailAddress);
			if (user is null)
			{
				return ResultData<User>.Error(2, ErrCode.NotFound);
			}
			var hashed = model.Password.MD5Hash().ConvertToString();
			if (user.Password != hashed)
			{
				IncreaseFailedPasswordCount(user);
				return ResultData<User>.Error(3, ErrCode.NotFound);
			}
			var validator = new UserValidator(optionService);
			var validateResult = validator.Validate(user);
			if (!validateResult.IsValid)
			{
				return ResultData<User>.Error(4, validateResult.Errors.First().ErrorCode);
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
			if (!exist) throw new BaseException("NotExist:User");
		}
		public void CheckExists(uint id)
		{
			var exist = Any(x => x.Id == id);
			if (!exist) throw new BaseException("NotExist:User");
		}
	}
}
