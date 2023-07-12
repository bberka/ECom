using ECom.Domain.DTOs.UserDTOs;
using Microsoft.AspNetCore.Authorization;

namespace ECom.WebApi.Controllers.UserControllers;

[AllowAnonymous]
public class AuthController : BaseUserController
{
  private readonly ILogService _logService;
  private readonly IUserJwtAuthenticator _userJwtAuthenticator;
  private readonly IUserService _userService;

  public AuthController(
    IUserService userService,
    IUserJwtAuthenticator userJwtAuthenticator,
    ILogService logService) {
    _userService = userService;
    _userJwtAuthenticator = userJwtAuthenticator;
    _logService = logService;
  }

  [HttpPost]
  public ActionResult<ResultData<UserLoginResponse>> Login([FromBody] LoginRequest model) {
    var res = _userJwtAuthenticator.Authenticate(model);
    var userId = res.Data?.User.Id;
    _logService.UserLog(res.ToResult(), userId, "Auth.Login", model.EmailAddress, model.EncryptedPassword);
    return res.ToActionResult();
  }

  [HttpPost]
  public ActionResult<Result> Register([FromBody] RegisterUserRequest model) {
    var res = _userService.Register(model);
    _logService.UserLog(res, null, "Auth.Register", model.EmailAddress);
    return res.ToActionResult();
  }
}