namespace ECom.AdminWebApi.Endpoints.ManagerEndpoints;

[EndpointRoute(typeof(UpdateAdminAccount))]
public class UpdateAdminAccount : EndpointBaseSync.WithRequest<UpdateAdminAccountRequest>.WithResult<CustomResult>
{
  private readonly IAdminService _adminService;
  private readonly ILogService _logService;

  public UpdateAdminAccount(IAdminService adminService, ILogService logService) {
    _adminService = adminService;
    _logService = logService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(UpdateAdminAccount), "Updates admin account")]
  [RequirePermission(AdminOperationType.AdminUpdate)]
  public override CustomResult Handle([FromBody] UpdateAdminAccountRequest request) {
    var authId = HttpContext.GetAdminId();
    var res = _adminService.UpdateAdmin(authId, request);
    _logService.AdminLog(res, authId, "Manager.Update", request);
    return res;
  }
}