using AspNetCore.Authorization.Extender;
using ECom.Domain;
using ECom.Domain.Entities;
using ECom.Shared.Constants;

namespace ECom.Application.Manager;

public class AdminJwtAuthenticator : IAdminJwtAuthenticator
{
  private readonly IAdminService _adminService;
  private readonly IDebugService _debugService;
  private readonly IUnitOfWork _unitOfWork;
  private readonly EasJWT _jwtManager;

  public AdminJwtAuthenticator(
    IAdminService adminService,
    IDebugService debugService,
    IUnitOfWork unitOfWork) {
    _adminService = adminService;
    _debugService = debugService;
    _unitOfWork = unitOfWork;
    _jwtManager = new EasJWT(JwtOption.This.Secret, JwtOption.This.Issuer, JwtOption.This.Audience);
  }


  public CustomResult<AdminLoginResponse> Authenticate(LoginRequest model) {
    AdminDto admin;
    var loginResult = _adminService.AdminLogin(model);
    if (!loginResult.Status) return loginResult.ToResult();
    admin = loginResult.Data!;
    var adminAsDic = admin.AsDictionary()!;
    var remove = adminAsDic.Where(x => x.Value == null || x.Value.ToString() == "");
    foreach (var kvp in remove) adminAsDic.Remove(kvp.Key);
    adminAsDic.Add("AdminOnly", "true");
    adminAsDic.Add(ClaimTypes.Role, admin.RoleId);
    if (ConstantMgr.IsDevelopment())
      adminAsDic.Add(ExtClaimTypes.AllPermissions, "true");
    else
      adminAsDic.Add(ExtClaimTypes.EndPointPermissions, admin.Permissions.ToList().CreatePermissionString());

    var expireMinutes = JwtOption.This.TokenExpireMinutes;
    var date = DateTime.UtcNow.AddMinutes(expireMinutes);
    var token = _jwtManager.GenerateToken(adminAsDic, date);
    string? rToken = null;
    if (model.RememberMe) {
      rToken = GenerateUniqueRefreshToken();
    }
    return new AdminLoginResponse {
      Admin = admin,
      Token = new JwtToken {
        ExpireUnix = date.ToUnixTime(),
        Token = token,
        RefreshToken = rToken
      }
  };
  }

  public CustomResult<AdminLoginResponse> Refresh(RefreshTokenRequest model) {
    var user = _unitOfWork.AdminRepository.FirstOrDefault(x => x.RefreshJwtToken == model.RefreshToken);
    if (user == null) return DomainResult.NotFound(nameof(Admin));
    var loginResponse = Authenticate(new LoginRequest {
      EmailAddress = user.EmailAddress,
      Password = user.Password,
      RememberMe = true
    });
    if (!loginResponse.Status) return loginResponse.ToResult();
    user.RefreshJwtToken = loginResponse.Data!.Token.Token;
    _unitOfWork.AdminRepository.Update(user);
    var dbRes = _unitOfWork.Save();
    if (!dbRes) return DomainResult.DbInternalError(nameof(Refresh));
    return loginResponse;

  }

  public bool Validate(ValidateTokenRequest model) {
    try {
      var result = _jwtManager.ValidateToken(model.Token);
      var isValid = result?.Identity?.IsAuthenticated == true;
      return isValid;
    }
    catch {
      //NOTE: this throws exception if token is expired
      return false;
    }

  }

  public ClaimsPrincipal? GetClaims(ValidateTokenRequest model) {
    var result = _jwtManager.ValidateToken(model.Token);
    return result;
  }

  private string GenerateUniqueRefreshToken() {
    var rToken = EasGenerate.RandomString(512);
    var exists = _unitOfWork.AdminRepository.Any(x => x.RefreshJwtToken == rToken);
    if (exists) return GenerateUniqueRefreshToken();
    return rToken;
  }
}