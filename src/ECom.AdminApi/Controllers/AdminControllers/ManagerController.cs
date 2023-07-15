using Microsoft.AspNetCore.Authorization;

namespace ECom.WebApi.Controllers.AdminControllers;

[Authorize(Roles = "Owner")]
public class ManagerController : BaseAdminController
{
  private readonly IAdminService _adminService;
  private readonly ILogService _logService;

  public ManagerController(
    IAdminService adminService,
    ILogService logService) {
    _adminService = adminService;
    _logService = logService;
  }

  [HttpGet]
  [RequirePermission(AdminOperationType.Admin_GetOrList)]
  public ActionResult<List<Admin>> List() {
    var adminId = HttpContext.GetAdminId();
    return _adminService.ListOtherAdmins(adminId);
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.Admin_Update)]
  public ActionResult<Result> EnableOrDisable([FromBody] int adminId) {
    var authorizedAdminId = HttpContext.GetAdminId();
    var res = _adminService.EnableOrDisableAdmin(authorizedAdminId, adminId);
    _logService.AdminLog(res, authorizedAdminId, "Manager.EnableOrDisable", adminId);
    return res.ToActionResult();
  }

  [HttpDelete]
  [RequirePermission(AdminOperationType.Admin_Delete)]
  public ActionResult<Result> Delete([FromBody] int adminId) {
    var authorizedAdminId = HttpContext.GetAdminId();
    var res = _adminService.DeleteAdmin(authorizedAdminId, adminId);
    _logService.AdminLog(res, authorizedAdminId, "Manager.Delete", adminId);
    return res.ToActionResult();
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.Admin_Add)]
  public ActionResult<Result> Add([FromBody] AddAdminRequest model) {
    var res = _adminService.AddAdmin(model);
    _logService.AdminLog(res, model.AuthenticatedAdminId, "Manager.Add", model.ToJsonString());
    return res.ToActionResult();
  }
}