namespace ECom.Service.UserApi.AuthEndpoints;

public class Register : EndpointBaseSync.WithRequest<Request_User_Register>.WithResult<Result>
{
  private readonly ILogService _logService;
  private readonly IUserAccountService _userService;

  public Register(IUserAccountService userService, ILogService logService) {
    _userService = userService;
    _logService = logService;
  }

  [AllowAnonymous]
  [Endpoint("/user/auth/register", HttpMethodType.POST)]
  [EndpointSwaggerOperation("User_Auth")]
  public override Result Handle(Request_User_Register requestUser) {
    var res = _userService.RegisterUser(requestUser);
    _logService.UserLog(UserActionType.Register, res, null, requestUser.EmailAddress);
    return res;
  }
}