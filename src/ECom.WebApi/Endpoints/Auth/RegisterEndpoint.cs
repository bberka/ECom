using ECom.Domain.DTOs.UserDTOs;
using Microsoft.Identity.Client;

namespace ECom.WebApi.Endpoints.Auth;

[AllowAnonymous]
[EndpointRoute(typeof(RegisterEndpoint))]
public class RegisterEndpoint : EndpointBaseSync.WithRequest<RegisterUserRequest>.WithResult<Result>
{
  private readonly IUserService _userService;
  private readonly ILogService _logService;

  public RegisterEndpoint(IUserService userService, ILogService logService) {
    _userService = userService;
    _logService = logService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(RegisterEndpoint), "Register a new user")]
  public override Result Handle(RegisterUserRequest request) {
    var res = _userService.Register(request);
    _logService.UserLog(res, null, "Auth.Register", request.EmailAddress);
    return res;
  }
}