namespace ECom.AdminApi.Endpoints.ManagerEndpoints;

[Authorize(Roles = "Owner")]
[EndpointRoute(typeof(GetAdmin))]
public class GetAdmin :EndpointBaseSync.WithRequest<int>.WithResult<CustomResult<Admin>>
{
  private readonly IAdminService _adminService;
  private readonly ILogService _logService;

  public GetAdmin(IAdminService adminService, ILogService logService) {
    _adminService = adminService;
    _logService = logService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(GetAdmin),"Gets admin")]
  public override CustomResult<Admin> Handle([FromQuery] int id ) {
    var authAdmin = HttpContext.GetAdminId();
    var adminResult = _adminService.GetAdmin(id);
    _logService.AdminLog(adminResult, authAdmin,"Admin.Get", id);
    return adminResult;
  }
}