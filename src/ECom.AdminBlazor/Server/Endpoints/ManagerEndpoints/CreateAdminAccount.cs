namespace ECom.AdminBlazor.Server.Endpoints.ManagerEndpoints;

[Authorize(Roles = "Owner")]
[EndpointRoute(typeof(CreateAdminAccount))]
public class CreateAdminAccount : EndpointBaseSync.WithRequest<AddAdminRequest>.WithResult<CustomResult>
{
  private readonly IAdminService _adminService;
  private readonly ILogService _logService;

  public CreateAdminAccount(ILogService logService, IAdminService adminService) {
    _logService = logService;
    _adminService = adminService;
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.AdminCreate)]
  [EndpointSwaggerOperation(typeof(CreateAdminAccount), "Creates new admin account")]
  public override CustomResult Handle(AddAdminRequest model) {
    var authId = HttpContext.GetAdminId();
    var res = _adminService.AddAdmin(model);
    _logService.AdminLog(res, authId, "Manager.Create", model.ToJsonString());
    return res;
  }
}