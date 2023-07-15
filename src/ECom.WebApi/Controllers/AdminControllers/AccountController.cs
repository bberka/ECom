namespace ECom.WebApi.Controllers.AdminControllers;

public class AccountController : BaseAdminController
{
  private readonly IAdminService _adminService;
  private readonly ILogService _logService;

  public AccountController(
    IAdminService adminService,
    ILogService logService) {
    _adminService = adminService;
    _logService = logService;
  }

  [HttpGet]
  public ActionResult<AdminDto> Get() {
    var admin = HttpContext.GetAdmin();
    return admin;
    //var res = _adminService.GetAdmin(adminId).ToActionResult();
    //_logService.AdminLog(res.ToResult(),adminId,"Account.Get");
    //return res;
  }


  [HttpPost]
  public ActionResult<Result> ChangePassword(ChangePasswordRequest model) {
    var res = _adminService.ChangePassword(model);
    _logService.AdminLog(res, model.AuthenticatedAdminId, "Account.ChangePasswordEndpoint", model.EncryptedOldPassword,
      model.EncryptedNewPassword);
    return res.ToActionResult();
  }
}