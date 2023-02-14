

using EasMe;
using ECom.Application.Validators;
using ECom.Domain.DTOs.UserDTOs;
using ECom.Domain.Extensions;
using ECom.Domain.Results;

namespace ECom.Application.Services
{


    public class UserService : IUserService
	{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptionService _optionService;
		private readonly IValidationService _validationService;

        public UserService(
            IUnitOfWork unitOfWork,
			IOptionService optionService,
			IValidationService validationService)
		{
            _unitOfWork = unitOfWork;
            this._optionService = optionService;
			this._validationService = validationService;
        }
		public Result Register(RegisterUserRequest model)
		{
			var user = model.ToUserEntity();
			_unitOfWork.UserRepository.Add(user);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
			}
            return DomainResult.User.RegisterSuccessResult();
		}
		public ResultData<UserDto> Login(LoginRequest model)
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

            var userNecessary = new UserDto()
            {
                TwoFactorType = user.TwoFactorType,
                Culture = user.Culture,
                EmailPassword = user.EmailAddress,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                IsEmailVerified = user.IsEmailVerified,
                TaxNumber = user.TaxNumber
            };
            return userNecessary;
        }
		public ResultData<User> GetUser(string email)
		{
			var user = _unitOfWork.UserRepository.GetFirstOrDefault(x => x.EmailAddress == email);
            if (user is null) return DomainResult.User.NotFoundResult(1);
            if (!user.IsValid) return DomainResult.User.NotValidResult(2);
            if (user.DeletedDate.HasValue) return DomainResult.User.DeletedResult(3);
            return user;
        }
        public ResultData<User> GetUser(int id)
		{
            var user = _unitOfWork.UserRepository.Find(id);
            if (user is null) return DomainResult.User.NotFoundResult(1);
            if (user.IsValid == false) return DomainResult.User.NotValidResult(2);
            if (user.DeletedDate.HasValue) return DomainResult.User.DeletedResult(3);
            return user;
        }


		public bool Exists(string email)
		{
			return _unitOfWork.UserRepository.Any(x => x.EmailAddress == email);
		}


        public Result ChangePassword(ChangePasswordRequest model)
        {
			var userResult = GetUser(model.AuthenticatedUserId);
            if (userResult.IsFailure) return userResult.ToResult();
            var user = userResult.Data;
			if(user.Password != model.EncryptedOldPassword)
            {
                return DomainResult.Base.PasswordWrongResult(1);
			}
            user.Password = Convert.ToBase64String(model.NewPassword.MD5Hash());
			_unitOfWork.UserRepository.Update(user);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
			}
            return DomainResult.User.ChangePasswordSuccessResult();
        }

        public Result Update(UpdateUserRequest model)
        {
            var userId = model.AuthenticatedUserId;
            if (userId < 1) return DomainResult.User.NotFoundResult(1);
            var user = _unitOfWork.UserRepository.Find(userId);
            if (user is null) return DomainResult.User.NotFoundResult(2);
            user.EmailAddress = model.EmailAddress;
            user.CitizenShipNumber = model.CitizenShipNumber;
            user.PhoneNumber = model.PhoneNumber;
            user.TaxNumber = model.TaxNumber;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            _unitOfWork.UserRepository.Update(user);
            var res = _unitOfWork.Save();
            if (!res) return DomainResult.DbInternalErrorResult(3);
            return DomainResult.User.UpdateSuccessResult();
        }

        public bool Exists(int id)
        {
			return _unitOfWork.UserRepository.Any(x => x.Id == id);
        }
    }
}
