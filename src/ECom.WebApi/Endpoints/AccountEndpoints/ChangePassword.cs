using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.AccountEndpoints;

[Authorize]
[EndpointRoute(typeof(ChangePassword))]
public class ChangePassword : EndpointBaseSync.WithRequest<ChangePasswordRequest>.WithResult<CustomResult>
{
  private readonly ILogService _logService;
  private readonly IUserService _userService;

  public ChangePassword(ILogService logService, IUserService userService) {
    _logService = logService;
    _userService = userService;
  }
  [HttpPost]
  [EndpointSwaggerOperation(typeof(ChangePassword),"Changes user password")]
  public override CustomResult Handle(ChangePasswordRequest request) {
    var res = _userService.ChangePassword(request);
    _logService.UserLog(res, request.AuthenticatedUserId, "Account.ChangePassword", request.EncryptedOldPassword,request.EncryptedNewPassword);
    return res;
  }

}