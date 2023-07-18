using ECom.Domain.DTOs.AdminDto;

namespace ECom.AdminApi.Endpoints.ManagerEndpoints;

[Authorize(Roles = "Owner")]
[EndpointRoute(typeof(CreateAdminAccount))]
public class CreateAdminAccount : EndpointBaseSync.WithRequest<AddAdminRequest>.WithResult<CustomResult>
{
  private readonly ILogService _logService;
  private readonly IAdminService _adminService;

  public CreateAdminAccount(ILogService logService, IAdminService adminService) {
    _logService = logService;
    _adminService = adminService;
  }
  [HttpPost]
  [RequirePermission(AdminOperationType.AdminCreate)]
  [EndpointSwaggerOperation(typeof(CreateAdminAccount), "Creates new admin account")]
  public override CustomResult Handle(AddAdminRequest model)
  {
    var res = _adminService.AddAdmin(model);
    _logService.AdminLog(res, model.AuthenticatedAdminId, "Manager.Create", model.ToJsonString());
    return res;
  }
}