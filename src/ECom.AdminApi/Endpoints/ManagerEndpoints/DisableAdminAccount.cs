using ECom.Domain.Entities;

namespace ECom.AdminApi.Endpoints.ManagerEndpoints;

[Authorize(Roles = "Owner")]
[EndpointRoute(typeof(DisableAdminAccount))]

public class DisableAdminAccount : EndpointBaseSync.WithRequest<int>.WithResult<CustomResult>
{
  private readonly ILogService _logService;
  private readonly IAdminService _adminService;

  public DisableAdminAccount(ILogService logService, IAdminService adminService) {
    _logService = logService;
    _adminService = adminService;
  }
  [HttpPost]
  [RequirePermission(AdminOperationType.AdminUpdate)]
  [EndpointSwaggerOperation(typeof(DisableAdminAccount),"Disables admin account")]

  public override CustomResult Handle([FromBody] int adminId)
  {
    var authorizedAdminId = HttpContext.GetAdminId();
    var res = _adminService.DisableAdmin(authorizedAdminId, adminId);
    _logService.AdminLog(res, authorizedAdminId, "Manager.Disable", adminId);
    return res;
  }
}