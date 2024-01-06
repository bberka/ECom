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
    if (!res) return DomResults.db_internal_error(nameof(RegisterUser));
    return DomResults.x_is_added_successfully("user");
  }

  public List<User> GetUsers() {
    return _unitOfWork.Users.ToList();
  }


  public Result<User> GetUser(string email) {
    var user = _unitOfWork.Users.AsNoTracking().Where(x => x.EmailAddress == email).FirstOrDefault();
    if (user is null || user.DeleteDate.HasValue) return DomResults.x_is_not_found("account");
    return user;
  }

  public Result<User> GetUser(Guid id) {
    var user = _unitOfWork.Users.Find(id);
    if (user is null || user.DeleteDate.HasValue) return DomResults.x_is_not_found("user");
    return user;
  }


  public Result ChangePassword(Guid userId, Request_Password_Change model) {
    var userResult = GetUser(userId);
    if (!userResult.Status) return userResult.ToResult();
    var user = userResult.Value;
    var encryptedPassword = model.OldPassword.ToHashedText();
    if (!user.Password.Equals(encryptedPassword, StringComparison.OrdinalIgnoreCase))
      return DomResults.wrong_password();
    user.Password = model.NewPassword.ToHashedText();
    _unitOfWork.Users.Update(user);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(ChangePassword));
    return DomResults.x_is_updated_successfully("password");
  }

  public Result UpdateUser(Guid userId, Request_User_Update model) {
    var user = _unitOfWork.Users.Find(userId);
    if (user is null || user.DeleteDate.HasValue) return DomResults.x_is_not_found("user");
    user.EmailAddress = model.EmailAddress;
    user.CitizenShipNumber = model.CitizenShipNumber;
    user.PhoneNumber = model.PhoneNumber;
    user.FirstName = model.FirstName;
    user.LastName = model.LastName;
    _unitOfWork.Users.Update(user);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(UpdateUser));
    return DomResults.x_is_updated_successfully("user");
  }
}