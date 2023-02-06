




using ECom.Application.Validators;
using ECom.Domain.ApiModels.Request;
using ECom.Domain.Extensions;
using System.Collections.Specialized;

namespace ECom.Application.Services
{


	public class UserService : IUserService
	{
		private readonly IEfEntityRepository<User> _userRepo;
		private readonly IOptionService _optionService;
		private readonly IValidationDbService _validationDbService;

		public UserService(
			IEfEntityRepository<User> userRepo,
			IOptionService optionService,
			IValidationDbService validationDbService)
		{
			this._userRepo = userRepo;
			this._optionService = optionService;
			this._validationDbService = validationDbService;
		}
		public Result Register(RegisterRequestModel model)
		{
			var user = model.ToUserEntity();
			var res = _userRepo.Add(user);
			if (!res) 
			{
				return Result.DbInternal(1);
			}
			return Result.Success(nameof(User));
		}
		public ResultData<User> Login(LoginRequestModel model)
		{
			var user = GetUser(model.EmailAddress);
			if (user is null)
			{
				return ResultData<User>.Warn(1, ErrorCode.NotFound, nameof(User));
			}
			var hashed = Convert.ToBase64String(model.Password.MD5Hash());
			if (user.Password != hashed)
			{
				IncreaseFailedPasswordCount(user);
                return ResultData<User>.Warn(2, ErrorCode.NotFound, nameof(User));
			}
			var validator = new UserValidator(_validationDbService);
			var validateResult = validator.Validate(user);
            if (!validateResult.IsValid)
            {
                var first = validateResult.Errors.First();
                return ResultData<User>.Warn(3, ErrorCode.ValidationError, nameof(User));
            }
            if (user.TwoFactorType != 0)
			{
				//TODO: implement two factor
			}
			UpdateSuccessLogin(user);
			return user;
		}
		public bool UpdateSuccessLogin(User user)
		{
			var req = HttpContextHelper.Current.GetNecessaryRequestData();
			user.TotalLoginCount++;
			user.LastLoginDate = DateTime.Now;
			user.LastLoginIp = req.IpAddress;
			user.LastLoginUserAgent = req.UserAgent;
			return _userRepo.Update(user);
		}
		public bool IncreaseFailedPasswordCount(User user)
		{
			user.FailedPasswordCount++;
			return _userRepo.Update(user);
		}
		public bool IncreaseFailedPasswordCount(int userId)
		{
			return _userRepo.UpdateWhereSingle(x => x.Id == userId, x => x.FailedPasswordCount++);
		}
		public User? GetUser(string email)
		{
			return _userRepo.GetFirstOrDefault(x => x.EmailAddress == email);
		}
		public User GetUserOrThrow(string email)
		{
			var user = _userRepo.GetFirstOrDefault(x => x.EmailAddress == email);
			if (user is null) throw new NullException(nameof(User));
			return user;
		}
		public void CheckExistsOrThrow(int id)
		{
			if(id < 1) throw new NotValidException("UserId");
			var exist = _userRepo.Any(x => x.Id == id);
			if (!exist) throw new NotFoundException(nameof(User));
		}
		public void CheckExistsOrThrow(uint id)
		{
            if (id < 1) throw new NotValidException("UserId");
            var exist = _userRepo.Any(x => x.Id == id);
            if (!exist) throw new NotFoundException(nameof(User));
        }

		public bool Exists(string email)
		{
			return _userRepo.Any(x => x.EmailAddress == email);
		}

		public User? GetUser(int id)
		{
			return _userRepo.Find(id);
		}

        public User GetUserOrThrow(int id)
        {
            var user = _userRepo.Find(id);
			if (user is null) throw new NotFoundException(nameof(User));
			return user;
        }

        public Result ChangePassword(ChangePasswordRequestModel model)
        {
			var user = GetUserOrThrow(model.AuthenticatedUserId);
			if(user.Password == model.EncryptedOldPassword)
			{
                return Result.Warn(1, ErrorCode.NotMatch, "RealPassword","OldPassword");
			}
			user.Password = Convert.ToBase64String(model.NewPassword.MD5Hash());
			var res = _userRepo.Update(user);
			if (!res)
			{
				return Result.DbInternal(2);
			}
			return Result.Success();
        }
    }
}
