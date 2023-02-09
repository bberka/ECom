

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
            var user = userResult.Data;
			if (user?.Password != model.EncryptedPassword)
			{
                return DomainResult.User.NotFoundResult(2);
			}
            if (user.TwoFactorType != 0)
			{
				//TODO: implement two factor
			}
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

        public Result Update(UpdateUserRequestModel model)
        {
            var userId = model.AuthenticatedUserId;
            if (userId < 1) return DomainResult.User.NotFoundResult(1);
            var user = _userRepo.Find(userId);
            if (user is null) return DomainResult.User.NotFoundResult(2);
            user.EmailAddress = model.EmailAddress;
            user.CitizenShipNumber = model.CitizenShipNumber;
            user.PhoneNumber = model.PhoneNumber;
            user.TaxNumber = model.TaxNumber;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            var res = _userRepo.Update(user);
            if (!res) return DomainResult.DbInternalErrorResult(3);
            return DomainResult.User.UpdateSuccessResult();
        }

        public bool Exists(int id)
        {
			return _userRepo.Any(x => x.Id == id);
        }
    }
}
