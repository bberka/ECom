namespace ECom.Service.UserApi.Controllers;

[AuthorizeUserOnly]
public class AccountController : UserControllerBase
{
  [FromServices]
  public ILogService LogService { get; set; }

  [FromServices]
  public IUserAccountService UserAccountService { get; set; }


  [Endpoint("/user/account/get", HttpMethodType.GET)]
  public UserDto Get() {
    var user = HttpContext.GetUser();
    return user;
  }

  [Endpoint("/user/account/update", HttpMethodType.POST)]
  public Result Update(Request_User_Update request) {
    var authId = HttpContext.GetAuthId();
    var res = UserAccountService.UpdateUser(authId, request);
    LogService.UserLog(UserActionType.UpdateAccount, res, authId, request.ToJsonString());
    return res;
  }
}