using ECom.Application.Attributes;
using ECom.Domain.Abstract.Services;
using ECom.Domain.Abstract.Services.User;
using ECom.Shared.DTOs;
using ECom.Shared.DTOs.UserDto;

namespace ECom.WebApi.Endpoints.AuthEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(Login))]
public class Login : EndpointBaseSync.WithRequest<LoginRequest>.WithResult<CustomResult<UserLoginResponse>>
{
  private readonly ILogService _logService;
  private readonly IUserJwtAuthenticator _userJwtAuthenticator;

  public Login(IUserJwtAuthenticator userJwtAuthenticator, ILogService logService) {
    _userJwtAuthenticator = userJwtAuthenticator;
    _logService = logService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(Login), "Login a user")]
  public override CustomResult<UserLoginResponse> Handle(LoginRequest request) {
    var res = _userJwtAuthenticator.Authenticate(request);
    var userId = res.Data?.User.Id;
    _logService.UserLog(res.ToResult(), userId, "Auth.Login", request.EmailAddress);
    return res;
  }
}