using ECom.Domain;
using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services;
using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Abstract.Services.User;
using ECom.Shared.Entities;

namespace ECom.Application.Services.BaseServices;

public abstract class UserAccountService : IUserAccountService
{
  protected readonly IOptionService OptionService;
  protected readonly IUnitOfWork UnitOfWork;
  protected readonly IValidationService ValidationService;
  protected UserAccountService(
    IUnitOfWork unitOfWork,
    IOptionService optionService,
    IValidationService validationService) {
    UnitOfWork = unitOfWork;
    OptionService = optionService;
    ValidationService = validationService;
  }


  public CustomResult RegisterUser(RegisterUserRequestDto model) {
    var user = User.FromRegisterRequest(model);
    UnitOfWork.Users.Add(user);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(RegisterUser));
    return DomainResult.OkUpdated(nameof(User));
  }

  public List<User> GetUsers() {
    return UnitOfWork.Users.ToList();
  }

  public CustomResult<UserDto> Login(LoginRequest model) {
    var userResult = GetUser(model.EmailAddress);
    if (!userResult.Status) return userResult.ToResult();
    var user = userResult.Data!;
    var encryptedPassword = model.IsHashed ? model.Password : model.Password.ToHashedText();
    if (!user.Password.Equals(encryptedPassword, StringComparison.Ordinal))
      return DomainResult.NoAccountFound(nameof(User)); //Or invalid password
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

  public CustomResult<User> GetUser(string email) {
    var user = UnitOfWork.Users.FirstOrDefault(x => x.EmailAddress == email);
    if (user is null) return DomainResult.NoAccountFound(nameof(User));
    if (user.DeleteDate.HasValue) return DomainResult.Invalid(nameof(User));
    return user;
  }

  public CustomResult<User> GetUser(Guid id) {
    var user = UnitOfWork.Users.Find(id);
    if (user is null) return DomainResult.NotFound(nameof(User));
    if (user.DeleteDate.HasValue) return DomainResult.Invalid(nameof(User));
    return user;
  }




  public CustomResult ChangePassword(Guid userId, ChangePasswordRequestDto model) {
    var userResult = GetUser(userId);
    if (!userResult.Status) return userResult.ToResult();
    var user = userResult.Data;
    var encryptedPassword = model.NewPassword.ToHashedText();
    if (user.Password != encryptedPassword) return DomainResult.NotFound("User");
    user.Password = encryptedPassword;
    UnitOfWork.Users.Update(user);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(ChangePassword));
    return DomainResult.OkUpdated(nameof(User));
  }

  public CustomResult UpdateUser(Guid userId, UpdateUserRequest model) {
    var user = UnitOfWork.Users.Find(userId);
    if (user is null) return DomainResult.NotFound(nameof(User));
    user.EmailAddress = model.EmailAddress;
    user.CitizenShipNumber = model.CitizenShipNumber;
    user.PhoneNumber = model.PhoneNumber;
    user.TaxNumber = model.TaxNumber;
    user.FirstName = model.FirstName;
    user.LastName = model.LastName;
    UnitOfWork.Users.Update(user);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateUser));
    return DomainResult.OkUpdated(nameof(User));
  }

}