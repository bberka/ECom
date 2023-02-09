

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
		private readonly IValidationService _validationService;
        private readonly ILogService _logService;

        public UserService(
			IEfEntityRepository<User> userRepo,
			IOptionService optionService,
			IValidationService validationService,
            ILogService logService)
		{
			this._userRepo = userRepo;
			this._optionService = optionService;
			this._validationService = validationService;
            _logService = logService;
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
			if (user?.Password != model.EncryptedPassword)
			{
				//_logService.UserLog(LogSeverity.WARN,2,"User.Login","WrongPassword",user.Id,model.EmailAddress,model.Password);
                return DomainResult.User.NotFoundResult(2);
			}
            if (user.TwoFactorType != 0)
			{
				//TODO: implement two factor
			}
            //_logService.UserLog_Info("User.Login", user.Id, model.EmailAddress);
            return user;
		}
		public ResultData<User> GetUser(string email)
		{
			var user = _userRepo.GetFirstOrDefault(x => x.EmailAddress == email);
            if (user is null) return DomainResult.User.NotFoundResult(1);
            if (!user.IsValid) return DomainResult.User.NotValidResult(2);
            if (user.DeletedDate.HasValue) return DomainResult.User.DeletedResult(3);
            if (user.IsTestAccount == ConstantMgr.IsDebug()) return DomainResult.User.TestAccountCanNotBeUsedResult(4);
            return user;
        }
        public ResultData<User> GetUser(int id)
		{
            var user = _userRepo.Find(id);
            if (user is null) return DomainResult.User.NotFoundResult(1);
            if (user.IsValid == false) return DomainResult.User.NotValidResult(2);
            if (user.DeletedDate.HasValue) return DomainResult.User.DeletedResult(3);
            if (user.IsTestAccount == ConstantMgr.IsDebug()) return DomainResult.User.TestAccountCanNotBeUsedResult(4);
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
