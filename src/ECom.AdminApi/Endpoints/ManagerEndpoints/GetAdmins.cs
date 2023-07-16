namespace ECom.AdminApi.Endpoints.ManagerEndpoints;

[EndpointRoute(typeof(GetAdmins))]
[Authorize(Roles = "Owner")]
public class GetAdmins : EndpointBaseSync.WithoutRequest.WithResult<List<Admin>>
{
  private readonly IAdminService _adminService;
  public GetAdmins(IAdminService adminService)
  {
    _adminService = adminService;
  }
  [HttpGet]
  [RequirePermission(AdminOperationType.AdminGet)]
  [EndpointSwaggerOperation(typeof(GetAdmins),"Gets all admins except the authenticated admin")]
  public override List<Admin> Handle()
  {
    var adminId = HttpContext.GetAdminId();
    return _adminService.ListOtherAdmins(adminId);
  }
}