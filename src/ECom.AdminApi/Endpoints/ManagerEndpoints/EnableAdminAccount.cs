using ECom.Domain.Entities;

namespace ECom.AdminApi.Endpoints.ManagerEndpoints;

[EndpointRoute(typeof(EnableAdminAccount))]
[Authorize(Roles = "Owner")]
public class EnableAdminAccount : EndpointBaseSync.WithRequest<int>.WithResult<CustomResult>
{
  private readonly ILogService _logService;
  private readonly IAdminService _adminService;

  public EnableAdminAccount(ILogService logService, IAdminService adminService)
  {
    _logService = logService;
    _adminService = adminService;
  }
  [HttpPost]
  [RequirePermission(AdminOperationType.AdminUpdate)]
  [EndpointSwaggerOperation(typeof(EnableAdminAccount),"Enables admin account")]
  public override CustomResult Handle([FromBody] int adminId)
  {
    var authorizedAdminId = HttpContext.GetAdminId();
    var res = _adminService.EnableAdmin(authorizedAdminId, adminId);
    _logService.AdminLog(res, authorizedAdminId, "Manager.Enable", adminId);
    return res;
  }
}