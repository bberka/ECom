using ECom.Domain.DTOs.AdminDto;

namespace ECom.AdminApi.Endpoints.ManagerEndpoints;

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
  [EndpointSwaggerOperation(typeof(UpdateAdminAccount),"Updates admin account")]
  [RequirePermission(AdminOperationType.AdminUpdate)]
  public override CustomResult Handle([FromBody] UpdateAdminAccountRequest request) {
    var res = _adminService.UpdateAdmin(request.AuthenticatedAdminId, request);
    _logService.AdminLog(res, request.AuthenticatedAdminId, "Manager.Update", request);
    return res;
    
  }
}