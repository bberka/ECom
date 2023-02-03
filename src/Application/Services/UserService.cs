




using ECom.Application.Validators;
using ECom.Domain.Extensions;

namespace ECom.Application.Services
{
	public interface IUserService
	{
		void CheckExistsOrThrow(int id);
		void CheckExistsOrThrow(uint id);
		bool Exists(string email);
		User? GetUser(string email);
		User? GetUser(int id);
		User GetUserSingle(string email);
		bool IncreaseFailedPasswordCount(int userId);
		bool IncreaseFailedPasswordCount(User user);
		ResultData<User> Login(LoginModel model);
		Result Register(RegisterModel model);
		bool UpdateSuccessLogin(User user);
	}

	public class UserService : IUserService
	{
		private readonly IEfEntityRepository<User> _userRepo;
		private readonly IOptionService optionService;
		private readonly IValidationDbService _validationDbService;

		public UserService(
			IEfEntityRepository<User> userRepo,
			IOptionService optionService,
			IValidationDbService validationDbService)
		{
			this._userRepo = userRepo;
			this.optionService = optionService;
			this._validationDbService = validationDbService;
		}
		public Result Register(RegisterModel model)
		{
			var user = model.ToUserEntity();
			var res = _userRepo.Add(user);
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
			var validator = new UserValidator(_validationDbService);
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
			var res = _userRepo.UpdateWhereSingle(x => x.Id == userId, x => x.FailedPasswordCount++);
			return res;
		}
		public User? GetUser(string email)
		{
			var user = _userRepo.GetFirstOrDefault(x => x.EmailAddress == email);
			return user;
		}
		public User GetUserSingle(string email)
		{
			var user = _userRepo.GetSingle(x => x.EmailAddress == email);
			return user;
		}
		public void CheckExistsOrThrow(int id)
		{
			if(id < 1) throw new BaseException("NotValid:UserId");
			var exist = _userRepo.Any(x => x.Id == id);
			if (!exist) throw new BaseException("NotExist:User");
		}
		public void CheckExistsOrThrow(uint id)
		{
			var exist = _userRepo.Any(x => x.Id == id);
			if (!exist) throw new BaseException("NotExist:User");
		}

		public bool Exists(string email)
		{
			return _userRepo.Any(x => x.EmailAddress == email);
		}

		public User? GetUser(int id)
		{
			return _userRepo.Find(id);
		}
	}
}
