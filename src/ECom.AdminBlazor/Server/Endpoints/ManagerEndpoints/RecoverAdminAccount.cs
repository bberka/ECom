namespace ECom.AdminBlazor.Server.Endpoints.ManagerEndpoints;

[EndpointRoute(typeof(RecoverAdminAccount))]
public class RecoverAdminAccount : EndpointBaseSync.WithRequest<int>.WithResult<CustomResult>
{
  private readonly IAdminService _adminService;

  public RecoverAdminAccount(IAdminService adminService) {
    _adminService = adminService;
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.AdminRecoverAccount)]
  [EndpointSwaggerOperation(typeof(RecoverAdminAccount), "Recovers deleted admin account")]
  public override CustomResult Handle([FromQuery] int id) {
    var admin = HttpContext.GetAdminId();
    var res = _adminService.RecoverAdmin(admin, id);
    return res;
  }
}