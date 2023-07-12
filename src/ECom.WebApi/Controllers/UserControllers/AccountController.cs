using ECom.Domain.DTOs.UserDTOs;

namespace ECom.WebApi.Controllers.UserControllers;

public class AccountController : BaseUserController
{
  private readonly ILogService _logService;
  private readonly IUserService _userService;

  public AccountController(
    IUserService userService,
    ILogService logService) {
    _userService = userService;
    _logService = logService;
  }

  [HttpGet]
  public ActionResult<UserDto> Get() {
    var user = HttpContext.GetUser();
    return user;
  }

  [HttpPost]
  //[ProducesDefaultResponseType(typeof(Result))]
  public IActionResult ChangePassword([FromBody] ChangePasswordRequest model) {
    var res = _userService.ChangePassword(model);
    _logService.UserLog(res, model.AuthenticatedUserId, "Account.ChangePassword", model.EncryptedOldPassword,
      model.EncryptedNewPassword);
    return res.ToActionResult();
  }

  [HttpPost]
  public ActionResult<Result> Update([FromBody] UpdateUserRequest model) {
    var userId = model.AuthenticatedUserId;
    var res = _userService.Update(model);
    _logService.UserLog(res, userId, "Account.Update", model.ToJsonString());
    return res.ToActionResult();
  }
}