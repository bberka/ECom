using AspNetCore.Authorization.Extender;
using ECom.Domain;
using ECom.Shared.Constants;

namespace ECom.Application.Manager;

public class AdminJwtAuthenticator : IAdminJwtAuthenticator
{
  private readonly IAdminService _adminService;
  private readonly IDebugService _debugService;
  private readonly EasJWT _jwtManager;

  public AdminJwtAuthenticator(
    IAdminService adminService,
    IDebugService debugService) {
    _adminService = adminService;
    _debugService = debugService;
    _jwtManager = new EasJWT(JwtOption.This.Secret, JwtOption.This.Issuer, JwtOption.This.Audience);
  }


  public CustomResult<AdminLoginResponse> Authenticate(LoginRequest model) {
    AdminDto admin;
    //if (ConstantMgr.IsDevelopment())
    //  admin = _debugService.GetAdminDto();
    //else {

    //}

    var loginResult = _adminService.AdminLogin(model);
    if (!loginResult.Status) return loginResult.ToResult();
    admin = loginResult.Data!;
    var adminAsDic = admin.AsDictionary()!;
    var remove = adminAsDic.Where(x => x.Value == null || x.Value.ToString() == "");
    foreach (var kvp in remove) adminAsDic.Remove(kvp.Key);
    adminAsDic.Add("AdminOnly", "true");
    adminAsDic.Add(ClaimTypes.Role, admin.RoleName);
    if (ConstantMgr.IsDevelopment())
      adminAsDic.Add(ExtClaimTypes.AllPermissions, "true");
    else
      adminAsDic.Add(ExtClaimTypes.EndPointPermissions, admin.Permissions.ToList().CreatePermissionString());

    var expireMinutes = JwtOption.This.TokenExpireMinutes;
    var date = DateTime.UtcNow.AddMinutes(expireMinutes);
    var token = _jwtManager.GenerateToken(adminAsDic, date);

    var jwtTokenModel = new JwtToken {
      ExpireUnix = date.ToUnixTime(),
      Token = token
    };
    return new AdminLoginResponse {
      Admin = admin,
      Token = jwtTokenModel
    };
  }
}