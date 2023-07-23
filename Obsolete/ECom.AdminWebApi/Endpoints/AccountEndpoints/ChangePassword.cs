namespace ECom.AdminWebApi.Endpoints.AccountEndpoints;

[EndpointRoute(typeof(ChangePassword))]
public class ChangePassword : EndpointBaseSync.WithRequest<ChangePasswordRequest>.WithResult<CustomResult>
{
  private readonly IAdminService _adminService;
  private readonly ILogService _logService;

  public ChangePassword(IAdminService adminService, ILogService logService) {
    _adminService = adminService;
    _logService = logService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(ChangePassword), "Changes authenticated admin password")]
  public override CustomResult Handle(ChangePasswordRequest request) {
    var authId = HttpContext.GetAdminId();
    var res = _adminService.ChangePassword(authId, request);
    _logService.AdminLog(res, authId, "Account.ChangePasswordEndpoint");
    return res;
  }
}