namespace ECom.Service.UserApi.AccountEndpoints;

public class Update : EndpointBaseSync.WithRequest<Request_User_Update>.WithResult<Result>
{
  private readonly ILogService _logService;
  private readonly IUserAccountService _userService;

  public Update(IUserAccountService userService, ILogService logService) {
    _userService = userService;
    _logService = logService;
  }

  [AuthorizeUserOnly]
  [Endpoint("/user/account/update", HttpMethodType.POST)]
  [EndpointSwaggerOperation("User_Account")]
  public override Result Handle(Request_User_Update request) {
    var authId = HttpContext.GetAuthId();
    var res = _userService.UpdateUser(authId, request);
    _logService.UserLog(UserActionType.UpdateAccount, res, authId, request.ToJsonString());
    return res;
  }
}