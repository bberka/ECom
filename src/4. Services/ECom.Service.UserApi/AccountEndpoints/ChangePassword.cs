namespace ECom.Service.UserApi.AccountEndpoints;

public class ChangePassword : EndpointBaseSync.WithRequest<Request_Password_Change>.WithResult<Result>
{
  [FromServices]
  public ILogService LogService { get; set; }

  [FromServices]
  public IUserAccountService UserAccountService { get; set; }

  [AuthorizeUserOnly]
  [Endpoint("/user/account/change-password", HttpMethodType.POST)]
  [EndpointSwaggerOperation("User_Account")]
  public override Result Handle(Request_Password_Change requestPassword) {
    var authId = HttpContext.GetAuthId();
    var res = UserAccountService.ChangePassword(authId, requestPassword);
    LogService.UserLog(UserActionType.ChangePassword, res, authId);
    return res;
  }
}