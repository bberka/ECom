using ECom.Domain.DTOs.UserDTOs;

namespace ECom.Application.Services;

public class UserService : IUserService
{
  private readonly IOptionService _optionService;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IValidationService _validationService;

  public UserService(
    IUnitOfWork unitOfWork,
    IOptionService optionService,
    IValidationService validationService) {
    _unitOfWork = unitOfWork;
    _optionService = optionService;
    _validationService = validationService;
  }

  public Result Register(RegisterUserRequest model) {
    var user = model.ToUserEntity();
    _unitOfWork.UserRepository.Insert(user);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.User.RegisterSuccessResult();
  }

  public ResultData<UserDto> Login(LoginRequest model) {
    var userResult = GetUser(model.EmailAddress);
    if (userResult.IsFailure) return userResult.ToResult();
    var user = userResult.Data;
    if (user?.Password != model.EncryptedPassword) return DomainResult.User.NotFoundResult();
    if (user.TwoFactorType != 0) {
      //TODO: implement two factor
    }

    var userNecessary = new UserDto {
      TwoFactorType = user.TwoFactorType,
      Culture = user.Culture,
      EmailAddress = user.EmailAddress,
      FirstName = user.FirstName,
      LastName = user.LastName,
      Id = user.Id,
      PhoneNumber = user.PhoneNumber,
      IsEmailVerified = user.IsEmailVerified,
      TaxNumber = user.TaxNumber
    };
    return userNecessary;
  }

  public ResultData<User> GetUser(string email) {
    var user = _unitOfWork.UserRepository.GetFirstOrDefault(x => x.EmailAddress == email);
    if (user is null) return DomainResult.User.NotFoundResult();
    if (!user.IsValid) return DomainResult.User.NotValidResult();
    if (user.DeletedDate.HasValue) return DomainResult.User.DeletedResult();
    return user;
  }

  public ResultData<User> GetUser(int id) {
    var user = _unitOfWork.UserRepository.GetById(id);
    if (user is null) return DomainResult.User.NotFoundResult();
    if (user.IsValid == false) return DomainResult.User.NotValidResult();
    if (user.DeletedDate.HasValue) return DomainResult.User.DeletedResult();
    return user;
  }


  public bool Exists(string email) {
    return _unitOfWork.UserRepository.Any(x => x.EmailAddress == email);
  }


  public Result ChangePassword(ChangePasswordRequest model) {
    var userResult = GetUser(model.AuthenticatedUserId);
    if (userResult.IsFailure) return userResult.ToResult();
    var user = userResult.Data;
    if (user.Password != model.EncryptedOldPassword) return DomainResult.Base.PasswordWrongResult();
    user.Password = Convert.ToBase64String(model.NewPassword.MD5Hash());
    _unitOfWork.UserRepository.Update(user);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.User.ChangePasswordSuccessResult();
  }

  public Result Update(UpdateUserRequest model) {
    var userId = model.AuthenticatedUserId;
    if (userId < 1) return DomainResult.User.NotFoundResult();
    var user = _unitOfWork.UserRepository.GetById(userId);
    if (user is null) return DomainResult.User.NotFoundResult();
    user.EmailAddress = model.EmailAddress;
    user.CitizenShipNumber = model.CitizenShipNumber;
    user.PhoneNumber = model.PhoneNumber;
    user.TaxNumber = model.TaxNumber;
    user.FirstName = model.FirstName;
    user.LastName = model.LastName;
    _unitOfWork.UserRepository.Update(user);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.User.UpdateSuccessResult();
  }

  public bool Exists(int id) {
    return _unitOfWork.UserRepository.Any(x => x.Id == id);
  }
}