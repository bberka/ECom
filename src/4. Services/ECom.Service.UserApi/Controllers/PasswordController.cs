using ECom.Foundation.Static;

namespace ECom.Service.UserApi.Controllers;

public class PasswordController : UserControllerBase
{
  [FromServices]
  public IUserAccountService UserAccountService { get; set; }

  [AuthorizeUserOnly]
  [Endpoint("/user/password/change", HttpMethodType.POST)]
  public Result Change(Request_Password_Change requestPassword) {
    var authId = HttpContext.GetAuthId();
    var res = UserAccountService.ChangePassword(authId, requestPassword);
    LogService.UserLog(UserActionType.ChangePassword, res, authId);
    return res;
  }
}