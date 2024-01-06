using ECom.Foundation.Static;

namespace ECom.Business.Services.UserServices;

public class UserJwtAuthenticator : IUserJwtAuthenticator
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IUserAccountService _userAccountService;

  public UserJwtAuthenticator(IUnitOfWork unitOfWork, IUserAccountService userAccountService) {
    _unitOfWork = unitOfWork;
    _userAccountService = userAccountService;
  }

  public Result<Response_User_Login> Authenticate(Request_Login model) {
    var user = _unitOfWork.Users
                          .AsNoTracking()
                          .Where(x => x.EmailAddress == model.EmailAddress)
                          .SingleOrDefault();
    var encryptedPassword = model.Password.ToHashedText();
    if (user is null
        || user.DeleteDate.HasValue
        || !user.Password.Equals(encryptedPassword, StringComparison.Ordinal)) return DomResults.x_is_not_found("account");
    if (user.TwoFactorType != 0) {
      //TODO: implement two factor
    }

    var userDto = user.ToDto();
    var dic = new Dictionary<string, object> {
      { "Id", userDto.Id },
      { "EmailAddress", userDto.EmailAddress },
      { "FirstName", userDto.FirstName },
      { "LastName", userDto.LastName },
      { "PhoneNumber", userDto.PhoneNumber },
      { "Culture", userDto.Culture },
      { "TwoFactorType", userDto.TwoFactorType },
      { "IsEmailVerified", userDto.IsEmailVerified },
      { "RegisterDate", userDto.RegisterDate },
      { DomClaimTypes.UserClaimType, true }
    };
    var refresh = EasGenerate.RandomString(StaticValues.MAX_TOKEN_LENGTH);
    var expire = DateTime.Now.AddMinutes(DomAppSettings.This.JwtTokenExpireMinutes);
    var unix = new DateTimeOffset(expire).ToUnixTimeSeconds();
    var token = JwtService.Jwt.GenerateToken(dic, expire);
    var response = new Response_User_Login {
      Token = new JwtToken {
        ExpireUnix = unix,
        Token = token,
        RefreshToken = refresh,
        ValidForMinutes = DomAppSettings.This.JwtTokenExpireMinutes
      },
      User = userDto
    };
    var userSession = new UserSession {
      UserId = user.Id,
      RefreshToken = refresh,
      ExpireDate = expire,
      RegisterDate = DateTime.Now,
      AccessToken = token,
      IsValid = true,
      SessionCreateType = SessionCreateType.Login
    };
    _unitOfWork.UserSessions.Add(userSession);
    var updateResult = _unitOfWork.Save();
    if (!updateResult) return DomResults.db_internal_error(nameof(Authenticate));

    return response;
  }

  public Result<Response_User_Login> Refresh(Request_Token_Refresh model) {
    throw new NotImplementedException();
  }

  public bool Validate(ValidateTokenRequest model) {
    throw new NotImplementedException();
  }

  public ClaimsPrincipal? GetClaims(ValidateTokenRequest model) {
    throw new NotImplementedException();
  }
}