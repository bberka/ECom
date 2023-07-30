using ECom.Application.Attributes;
using ECom.Domain.Abstract.Services;
using ECom.Domain.Abstract.Services.User;
using ECom.Shared.DTOs;

namespace ECom.WebApi.Endpoints.AuthEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(Register))]
public class Register : EndpointBaseSync.WithRequest<RegisterUserRequest>.WithResult<CustomResult>
{
  private readonly ILogService _logService;
  private readonly IUserAccountService _userService;

  public Register(IUserAccountService userService, ILogService logService) {
    _userService = userService;
    _logService = logService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(Register), "Register a new user")]
  public override CustomResult Handle(RegisterUserRequest request) {
    var res = _userService.RegisterUser(request);
    _logService.UserLog(res, null, "Auth.Register", request.EmailAddress);
    return res;
  }
}