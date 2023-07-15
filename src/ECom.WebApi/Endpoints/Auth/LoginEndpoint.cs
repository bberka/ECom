using ECom.Domain.DTOs.UserDTOs;

namespace ECom.WebApi.Endpoints.Auth;

[AllowAnonymous]
[EndpointRoute(typeof(LoginEndpoint))]
public class LoginEndpoint : EndpointBaseSync.WithRequest<LoginRequest>.WithResult<ResultData<UserLoginResponse>>
{
  private readonly IUserJwtAuthenticator _userJwtAuthenticator;
  private readonly ILogService _logService;

  public LoginEndpoint(IUserJwtAuthenticator userJwtAuthenticator,ILogService logService) {
    _userJwtAuthenticator = userJwtAuthenticator;
    _logService = logService;
  }
  [HttpPost]
  [EndpointSwaggerOperation(typeof(LoginEndpoint), "Login a user")]
  public override ResultData<UserLoginResponse> Handle(LoginRequest request) {
    var res = _userJwtAuthenticator.Authenticate(request);
    var userId = res.Data?.User.Id;
    _logService.UserLog(res.ToResult(), userId, "Auth.Login", request.EmailAddress, request.EncryptedPassword);
    return res;
  }
}