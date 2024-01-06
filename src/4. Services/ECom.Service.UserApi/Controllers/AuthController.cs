using ECom.Foundation.DTOs.Response;

namespace ECom.Service.UserApi.Controllers;

[NotAuthorizedOnly]
[AllowAnonymous]
public class AuthController : UserControllerBase
{
  [FromServices]
  public IUserJwtAuthenticator UserJwtAuthenticator { get; set; }

  [FromServices]
  public IUserAccountService UserAccountService { get; set; }


  [Endpoint("/user/auth/login", HttpMethodType.POST)]
  public Result<Response_User_Login> Login(Request_Login request) {
    var res = UserJwtAuthenticator.Authenticate(request);
    var userId = res.Data?.User.Id;
    LogService.UserLog(UserActionType.Login, res, userId, request.EmailAddress);
    return res;
  }

  [Endpoint("/user/auth/register", HttpMethodType.POST)]
  public Result Register(Request_User_Register requestUser) {
    var res = UserAccountService.RegisterUser(requestUser);
    LogService.UserLog(UserActionType.Register, res, null, requestUser.EmailAddress);
    return res;
  }
}