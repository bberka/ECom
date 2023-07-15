
namespace ECom.AdminApi.Endpoints.AccountEndpoints;

[EndpointRoute(typeof(ChangePassword))]
public class ChangePassword : EndpointBaseSync.WithRequest<ChangePasswordRequest>.WithResult< Result>
{
  private readonly IAdminService _adminService;
  private readonly ILogService _logService;

  public ChangePassword(IAdminService adminService, ILogService logService) {
    _adminService = adminService;
    _logService = logService;
  }
  [HttpPost]
  [EndpointSwaggerOperation(typeof(ChangePassword), "Changes authenticated admin password")]
  public override Result Handle(ChangePasswordRequest request) {
    var res = _adminService.ChangePassword(request);
    _logService.AdminLog(res, request.AuthenticatedAdminId, "Account.ChangePasswordEndpoint", request.EncryptedOldPassword,
      request.EncryptedNewPassword);
    return res;
  }
}