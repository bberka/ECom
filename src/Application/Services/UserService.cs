




using EasMe;
using ECom.Application.Validators;
using ECom.Domain.Extensions;
using ECom.Domain.Results;

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
                return DomainResult.DbInternalErrorResult(1);
			}
            return DomainResult.User.RegisterSuccessResult();
		}
		public ResultData<User> Login(LoginRequestModel model)
		{
			var userResult = GetUser(model.EmailAddress);
            if (userResult.IsFailure)
            {
                return userResult.ToResult();
            }
            var user = userResult.Data; //Ignore null warning
			if (user.Password != model.EncryptedPassword)
			{
				IncreaseFailedPasswordCount(user);
                return DomainResult.User.NotFoundResult(2);
			}
			var validator = new UserValidator();
			var validateResult = validator.Validate(user);
            if (!validateResult.IsValid)
            {
                var first = validateResult.Errors.First();
                return DomainResult.ValidationErrorResult(3, first.PropertyName, first.ErrorCode);
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
		public ResultData<User> GetUser(string email)
		{
			var user = _userRepo.GetFirstOrDefault(x => x.EmailAddress == email);
            if (user is null) return DomainResult.User.NotFoundResult(1);
            return user;
        }
        public ResultData<User> GetUser(int id)
		{
            var user = _userRepo.Find(id);
            if (user is null) return DomainResult.User.NotFoundResult(1);
            return user;
        }


		public bool Exists(string email)
		{
			return _userRepo.Any(x => x.EmailAddress == email);
		}


        public Result ChangePassword(ChangePasswordRequestModel model)
        {
			var userResult = GetUser(model.AuthenticatedUserId);
            if (userResult.IsFailure) return userResult.ToResult();
            var user = userResult.Data;
			if(user.Password != model.EncryptedOldPassword)
            {
                return DomainResult.Base.PasswordWrongResult(1);
			}
            user.Password = Convert.ToBase64String(model.NewPassword.MD5Hash());
			var res = _userRepo.Update(user);
			if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
			}
            return DomainResult.User.ChangePasswordSuccessResult();
        }

        public bool Exists(int id)
        {
			return _userRepo.Any(x => x.Id == id);
        }
    }
}
