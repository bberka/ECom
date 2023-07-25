using ECom.Application.Attributes;
using ECom.Domain.Abstract.Services;
using ECom.Domain.Abstract.Services.User;
using ECom.Shared.DTOs;
using Serilog;

namespace ECom.WebApi.Endpoints.AccountEndpoints;

[Authorize]
[EndpointRoute(typeof(ChangePassword))]
public class ChangePassword : EndpointBaseSync.WithRequest<ChangePasswordRequest>.WithResult<CustomResult>
{
  private readonly ILogService _logService;
  private readonly IUserAccountService _userService;

  public ChangePassword(ILogService logService, IUserAccountService userService) {
    _logService = logService;
    _userService = userService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(ChangePassword), "Changes user password")]
  public override CustomResult Handle(ChangePasswordRequest request) {
    var authId = HttpContext.GetUserId();
    var res = _userService.ChangePassword(authId, request);
    _logService.UserLog(res, authId, "Account.ChangePassword");
    return res;
  }
}