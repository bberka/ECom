namespace ECom.AdminWebApi.Endpoints.ManagerEndpoints;

[EndpointRoute(typeof(GetAdmins))]
[Authorize(Roles = "Owner")]
public class GetAdmins : EndpointBaseSync.WithoutRequest.WithResult<List<AdminDto>>
{
  private readonly IAdminService _adminService;
  private readonly ILogService _logService;

  public GetAdmins(IAdminService adminService, ILogService logService) {
    _adminService = adminService;
    _logService = logService;
  }

  [HttpGet]
  [RequirePermission(AdminOperationType.AdminGet)]
  [EndpointSwaggerOperation(typeof(GetAdmins), "Gets all admins except the authenticated admin")]
  public override List<AdminDto> Handle() {
    var adminId = HttpContext.GetAdminId();
    return _adminService.ListOtherAdmins(adminId);
  }
}