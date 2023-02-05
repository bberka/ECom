




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
			if (res == false) throw new DbInternalException(nameof(Register));
			return Result.Success();
		}
		public ResultData<User> Login(LoginRequestModel model)
		{
			var user = GetUser(model.EmailAddress);
			if (user is null) throw new NotFoundException(nameof(User));
			var hashed = Convert.ToBase64String(model.Password.MD5Hash());
			if (user.Password != hashed)
			{
				IncreaseFailedPasswordCount(user);
				throw new NotFoundException(nameof(User));
			}
			var validator = new UserValidator(_validationDbService);
			var validateResult = validator.Validate(user);
			if (!validateResult.IsValid)
			{
				//throw new ValidationErrorException();	
				return ResultData<User>.Error(
					3,
					ErrCode.ValidationError ,
					validateResult.Errors.Select(x => $"{x.ErrorCode}:{x.PropertyName}").ToArray());
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
			throw new NotFoundException(nameof(User));
		}
		public void CheckExistsOrThrow(int id)
		{
			if(id < 1) throw new NotValidException("UserId");
			var exist = _userRepo.Any(x => x.Id == id);
			if (!exist) throw new NotFoundException("User");
		}
		public void CheckExistsOrThrow(uint id)
		{
            if (id < 1) throw new NotValidException("UserId");
            var exist = _userRepo.Any(x => x.Id == id);
            if (!exist) throw new NotFoundException("User");
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
    }
}
