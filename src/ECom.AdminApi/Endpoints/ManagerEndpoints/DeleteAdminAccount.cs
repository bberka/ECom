﻿using ECom.Domain.Entities;

namespace ECom.AdminApi.Endpoints.ManagerEndpoints;
[Authorize(Roles = "Owner")]
[EndpointRoute(typeof(DeleteAdminAccount))]
public class DeleteAdminAccount : EndpointBaseSync.WithRequest<int>.WithResult<CustomResult>
{
  private readonly ILogService _logService;
  private readonly IAdminService _adminService;

  public DeleteAdminAccount(ILogService logService, IAdminService adminService) {
    _logService = logService;
    _adminService = adminService;
  }
  [HttpDelete]
  [RequirePermission(AdminOperationType.AdminDelete)]
  [EndpointSwaggerOperation(typeof(DeleteAdminAccount),"Deletes admin account")]
  public override CustomResult Handle( int id)
  {
    var authorizedAdminId = HttpContext.GetAdminId();
    var res = _adminService.DeleteAdmin(authorizedAdminId, id);
    _logService.AdminLog(res, authorizedAdminId, "Manager.Delete", id);
    return res;
  }
}