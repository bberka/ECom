using ECom.Domain.DTOs.UserDTOs;

namespace ECom.Application.Manager;

public class UserJwtAuthenticator : IUserJwtAuthenticator
{
  private readonly IDebugService _debugService;
  public readonly EasJWT _jwtManager;
  private readonly IUserService _userService;

  public UserJwtAuthenticator(
    IUserService userService,
    IDebugService debugService) {
    _userService = userService;
    _debugService = debugService;
    _jwtManager = new EasJWT(JwtOption.This.Secret, JwtOption.This.Issuer, JwtOption.This.Audience);
  }


  public CustomResult<UserLoginResponse> Authenticate(LoginRequest model) {
    UserDto user;
    if (ConstantMgr.IsDevelopment()) {
      user = _debugService.GetUserDto();
    }
    else {
      var loginResult = _userService.Login(model);
      if (!loginResult) return loginResult.ToResult();
      user = loginResult.Data!;
    }

    var userAsDic = user.AsDictionary();
    var remove = userAsDic.Where(x => x.Value == null || x.Value.ToString() == "");
    foreach (var kvp in remove) userAsDic.Remove(kvp.Key);
    userAsDic.Add("UserOnly", "true");
    userAsDic.Add(ClaimTypes.Role, "User");
    var expireMinutes = JwtOption.This.TokenExpireMinutes;
    var date = DateTime.UtcNow.AddMinutes(expireMinutes);
    var token = _jwtManager.GenerateToken(userAsDic, date);
    var jwtTokenModel = new JwtToken {
      ExpireUnix = date.ToUnixTime(),
      Token = token
    };
    return new UserLoginResponse {
      User = user,
      Token = jwtTokenModel
    };
  }
}