namespace ECom.AdminWebApi.Endpoints.ManagerEndpoints;

[Authorize(Roles = "Owner")]
[EndpointRoute(typeof(DeleteAdminAccount))]
public class DeleteAdminAccount : EndpointBaseSync.WithRequest<int>.WithResult<CustomResult>
{
  private readonly IAdminService _adminService;
  private readonly ILogService _logService;

  public DeleteAdminAccount(ILogService logService, IAdminService adminService) {
    _logService = logService;
    _adminService = adminService;
  }

  [HttpDelete]
  [RequirePermission(AdminPermission.ManageAdmins)]
  [EndpointSwaggerOperation(typeof(DeleteAdminAccount), "Deletes admin account")]
  public override CustomResult Handle([FromQuery] int id) {
    var authorizedAdminId = HttpContext.GetAdminId();
    var res = _adminService.DeleteAdmin(authorizedAdminId, id);
    _logService.AdminLog(res, authorizedAdminId, "Manager.Delete", id);
    return res;
  }
}