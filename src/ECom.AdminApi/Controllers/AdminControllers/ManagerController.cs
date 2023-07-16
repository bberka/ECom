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
  [RequirePermission(AdminOperationType.AdminGet)]
  public ActionResult<List<Admin>> List() {
    var adminId = HttpContext.GetAdminId();
    return _adminService.ListOtherAdmins(adminId);
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.AdminUpdate)]
  public ActionResult<CustomResult> Disable([FromBody] int adminId) {
    var authorizedAdminId = HttpContext.GetAdminId();
    var res = _adminService.DisableAdmin(authorizedAdminId, adminId);
    _logService.AdminLog(res, authorizedAdminId, "Manager.Disable", adminId);
    return res.ToActionResult();
  }
  [HttpPost]
  [RequirePermission(AdminOperationType.AdminUpdate)]
  public ActionResult<CustomResult> Enable([FromBody] int adminId) {
    var authorizedAdminId = HttpContext.GetAdminId();
    var res = _adminService.EnableAdmin(authorizedAdminId, adminId);
    _logService.AdminLog(res, authorizedAdminId, "Manager.Enable", adminId);
    return res.ToActionResult();
  }

  [HttpDelete]
  [RequirePermission(AdminOperationType.AdminDelete)]
  public ActionResult<CustomResult> Delete([FromBody] int adminId) {
    var authorizedAdminId = HttpContext.GetAdminId();
    var res = _adminService.DeleteAdmin(authorizedAdminId, adminId);
    _logService.AdminLog(res, authorizedAdminId, "Manager.Delete", adminId);
    return res.ToActionResult();
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.AdminAdd)]
  public ActionResult<CustomResult> Add([FromBody] AddAdminRequest model) {
    var res = _adminService.AddAdmin(model);
    _logService.AdminLog(res, model.AuthenticatedAdminId, "Manager.Add", model.ToJsonString());
    return res.ToActionResult();
  }
}