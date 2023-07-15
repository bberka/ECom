using Ardalis.ApiEndpoints;
using ECom.WebApi.Attributes;
using Microsoft.AspNetCore.Authorization;

namespace ECom.WebApi.Endpoints.Account;

[Authorize]
[EndpointRoute(typeof(ChangePasswordEndpoint))]
public class ChangePasswordEndpoint : EndpointBaseSync.WithRequest<ChangePasswordRequest>.WithResult<Result>
{
  private readonly ILogService _logService;
  private readonly IUserService _userService;

  public ChangePasswordEndpoint(ILogService logService, IUserService userService) {
    _logService = logService;
    _userService = userService;
  }
  [HttpPost]
  [EndpointSwaggerOperation(typeof(ChangePasswordEndpoint),"Changes user password")]
  public override Result Handle(ChangePasswordRequest request) {
    var res = _userService.ChangePassword(request);
    _logService.UserLog(res, request.AuthenticatedUserId, "Account.ChangePasswordEndpoint", request.EncryptedOldPassword,request.EncryptedNewPassword);
    return res;
  }

}