namespace ECom.AdminApi.Endpoints.ManagerEndpoints;

[Authorize(Roles = "Owner")]
[EndpointRoute(typeof(AddAdminAccount))]
public class AddAdminAccount : EndpointBaseSync.WithRequest<AddAdminRequest>.WithResult<CustomResult>
{
  private readonly ILogService _logService;
  private readonly IAdminService _adminService;

  public AddAdminAccount(ILogService logService, IAdminService adminService) {
    _logService = logService;
    _adminService = adminService;
  }
  [HttpPost]
  [RequirePermission(AdminOperationType.AdminAdd)]
  [EndpointSwaggerOperation(typeof(AddAdminAccount), "Adds admin account")]
  public override CustomResult Handle(AddAdminRequest model)
  {
    var res = _adminService.AddAdmin(model);
    _logService.AdminLog(res, model.AuthenticatedAdminId, "Manager.Add", model.ToJsonString());
    return res;
  }
}