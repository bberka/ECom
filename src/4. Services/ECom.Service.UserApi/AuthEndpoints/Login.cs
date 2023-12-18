using ECom.Foundation.DTOs.Response;

namespace ECom.Service.UserApi.AuthEndpoints;

public class Login : EndpointBaseSync.WithRequest<Request_Login>.WithResult<Result<Response_User_Login>>
{
  private readonly ILogService _logService;
  private readonly IUserJwtAuthenticator _userJwtAuthenticator;

  public Login(IUserJwtAuthenticator userJwtAuthenticator, ILogService logService) {
    _userJwtAuthenticator = userJwtAuthenticator;
    _logService = logService;
  }

  [AllowAnonymous]
  [Endpoint("/user/auth/login", HttpMethodType.POST)]
  [EndpointSwaggerOperation("User_Auth")]
  public override Result<Response_User_Login> Handle(Request_Login request) {
    var res = _userJwtAuthenticator.Authenticate(request);
    var userId = res.Data?.User.Id;
    _logService.UserLog(UserActionType.Login, res, userId, request.EmailAddress);
    return res;
  }
}