namespace ECom.Business.Services.UserServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class UserAccountService : IUserAccountService
{
  private readonly IOptionService _optionService;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IValidationService _validationService;

  public UserAccountService(
    IUnitOfWork unitOfWork,
    IOptionService optionService,
    IValidationService validationService) {
    _unitOfWork = unitOfWork;
    _optionService = optionService;
    _validationService = validationService;
  }


  public Result RegisterUser(Request_User_Register model) {
    var user = model.FromRequestRegisterUser();
    _unitOfWork.Users.Add(user);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(RegisterUser));
    return DefResult.OkAdded(User.LocKey);
  }

  public List<User> GetUsers() {
    return _unitOfWork.Users.ToList();
  }


  public Result<User> GetUser(string email) {
    var user = _unitOfWork.Users.AsNoTracking().Where(x => x.EmailAddress == email).FirstOrDefault();
    if (user is null) return DefResult.NoAccountFound(User.LocKey);
    if (user.DeleteDate.HasValue) return DefResult.Invalid(User.LocKey);
    return user;
  }

  public Result<User> GetUser(Guid id) {
    var user = _unitOfWork.Users.Find(id);
    if (user is null) return DefResult.NotFound(User.LocKey);
    if (user.DeleteDate.HasValue) return DefResult.Invalid(User.LocKey);
    return user;
  }


  public Result ChangePassword(Guid userId, Request_Password_Change model) {
    var userResult = GetUser(userId);
    if (!userResult.Status) return userResult.ToResult();
    var user = userResult.Data;
    var encryptedPassword = model.OldPassword.ToHashedText();
    if (!user.Password.Equals(encryptedPassword, StringComparison.OrdinalIgnoreCase))
      return DefResult.WrongPassword();
    user.Password = model.NewPassword.ToHashedText();
    _unitOfWork.Users.Update(user);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(ChangePassword));
    return DefResult.OkUpdated(User.LocKey);
  }

  public Result UpdateUser(Guid userId, Request_User_Update model) {
    var user = _unitOfWork.Users.Find(userId);
    if (user is null) return DefResult.NotFound(User.LocKey);
    user.EmailAddress = model.EmailAddress;
    user.CitizenShipNumber = model.CitizenShipNumber;
    user.PhoneNumber = model.PhoneNumber;
    user.FirstName = model.FirstName;
    user.LastName = model.LastName;
    _unitOfWork.Users.Update(user);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(UpdateUser));
    return DefResult.OkUpdated(User.LocKey);
  }
}