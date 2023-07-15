namespace ECom.WebApi.Controllers.AdminControllers;


public class AuthController : BaseAdminController
{
  private readonly IAdminJwtAuthenticator _adminJwtAuthenticator;
  private readonly IAdminService _adminService;
  private readonly ILogService _logService;
  private readonly IOptionService _optionService;

  public AuthController(
    IAdminService adminService,
    IOptionService optionService,
    IAdminJwtAuthenticator adminJwtAuthenticator,
    ILogService logService) {
    _adminService = adminService;
    _optionService = optionService;
    _adminJwtAuthenticator = adminJwtAuthenticator;
    _logService = logService;
  }

  [HttpPost]
  public ActionResult<ResultData<AdminLoginResponse>> Login([FromBody] LoginRequest model) {
    var res = _adminJwtAuthenticator.Authenticate(model);
    var adminId = res.Data?.Admin.Id;
    _logService.AdminLog(res.ToResult(), adminId, "Auth.Login", model.EmailAddress, model.EncryptedPassword);
    return res.ToActionResult();
  }
}