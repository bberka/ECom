namespace ECom.AdminApi.Endpoints.ManagerEndpoints;

[Authorize(Roles = "Owner")]
[EndpointRoute(typeof(GetAdmin))]
public class GetAdmin :EndpointBaseSync.WithRequest<GetAdminRequest>.WithResult<CustomResult<Admin>>
{
  private readonly IAdminService _adminService;
  private readonly ILogService _logService;

  public GetAdmin(IAdminService adminService, ILogService logService) {
    _adminService = adminService;
    _logService = logService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(GetAdmin),"Gets admin")]
  public override CustomResult<Admin> Handle([FromRoute] GetAdminRequest request) {
    var adminResult = _adminService.GetAdmin(request.Id);
    _logService.AdminLog(adminResult,request.AuthenticatedAdminId,"Admin.Get",request.Id);
    return adminResult;
  }
}