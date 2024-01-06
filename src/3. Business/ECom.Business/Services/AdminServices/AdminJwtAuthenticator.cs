namespace ECom.Business.Services.AdminServices;

public class AdminJwtAuthenticator : IAdminJwtAuthenticator
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IUserAccountService _userAccountService;

  public AdminJwtAuthenticator(IUnitOfWork unitOfWork,
                               IUserAccountService userAccountService) {
    _unitOfWork = unitOfWork;
    _userAccountService = userAccountService;
  }

  public Result<Response_Admin_Login> Authenticate(Request_Login model) {
    var admin = _unitOfWork.Admins.AsNoTracking()
                           .Include(x => x.Role)
                           .ThenInclude(x => x.PermissionRoles)
                           .Where(x => x.EmailAddress == model.EmailAddress)
                           .SingleOrDefault();
    if (admin is null) return DefResult.NoAccountFound(Admin.LocKey);
    if (admin.DeleteDate.HasValue)
      return DefResult.NoAccountFound(Admin.LocKey);
    // return DefResult.Invalid(User.LocKey);

    var encryptedPassword = model.Password.ToHashedText();
    if (!admin.Password.Equals(encryptedPassword, StringComparison.Ordinal))
      return DefResult.NoAccountFound(Admin.LocKey); //Or invalid password
    if (admin.TwoFactorType != 0) {
      //TODO: implement two factor
    }

    var adminDto = admin.ToDto();
    var dic = new Dictionary<string, object> {
      { "Id", admin.Id },
      { "EmailAddress", admin.EmailAddress },
      { "FirstName", admin.FirstName },
      { "LastName", admin.LastName },
      { "PhoneNumber", admin.PhoneNumber },
      { "Culture", admin.Culture },
      { "TwoFactorType", admin.TwoFactorType },
      { "RegisterDate", admin.RegisterDate },
      { EComClaimTypes.AdminClaimType, true }
    };
    var refresh = EasGenerate.RandomString(ConstantContainer.MaxTokenLength);
    var expire = DateTime.Now.AddMinutes(EComAppSettings.This.JwtTokenExpireMinutes);
    var unix = new DateTimeOffset(expire).ToUnixTimeSeconds();
    var token = JwtService.Jwt.GenerateToken(dic, expire);
    var response = new Response_Admin_Login {
      Token = new JwtToken {
        ExpireUnix = unix,
        Token = token,
        RefreshToken = refresh,
        ValidForMinutes = EComAppSettings.This.JwtTokenExpireMinutes
      },
      Admin = adminDto
    };
    var adminSession = new AdminSession {
      AdminId = admin.Id,
      RefreshToken = refresh,
      ExpireDate = expire,
      RegisterDate = DateTime.Now,
      AccessToken = token,
      IsValid = true,
      SessionCreateType = SessionCreateType.Login
    };
    _unitOfWork.AdminSessions.Add(adminSession);
    var updateResult = _unitOfWork.Save();
    if (!updateResult) return DefResult.DbInternalError(nameof(Authenticate));
    return response;
  }

  public Result<Response_Admin_Login> Refresh(Request_Token_Refresh model) {
    throw new NotImplementedException();
  }

  public bool Validate(ValidateTokenRequest model) {
    throw new NotImplementedException();
  }

  public ClaimsPrincipal? GetClaims(ValidateTokenRequest model) {
    throw new NotImplementedException();
  }
}