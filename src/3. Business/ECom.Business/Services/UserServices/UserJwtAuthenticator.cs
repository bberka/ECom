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
    var user = _unitOfWork.Users.AsNoTracking()
                          .Where(x => x.EmailAddress == model.EmailAddress)
                          .FirstOrDefault();
    if (user is null) return DefResult.NoAccountFound(User.LocKey);
    if (user.DeleteDate.HasValue)
      return DefResult.NoAccountFound(User.LocKey);
    // return DefResult.Invalid(User.LocKey);

    var encryptedPassword = model.Password.ToHashedText();
    if (!user.Password.Equals(encryptedPassword, StringComparison.Ordinal))
      return DefResult.NoAccountFound(User.LocKey); //Or invalid password
    if (user.TwoFactorType != 0) {
      //TODO: implement two factor
    }

    var userDto = new UserDto {
      TwoFactorType = user.TwoFactorType,
      Culture = user.Culture,
      EmailAddress = user.EmailAddress,
      FirstName = user.FirstName,
      LastName = user.LastName,
      Id = user.Id,
      PhoneNumber = user.PhoneNumber,
      IsEmailVerified = user.IsEmailVerified,
      RegisterDate = user.RegisterDate
    };
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
      { EComClaimTypes.UserClaimType, true }
    };
    var refresh = EasGenerate.RandomString(ConstantContainer.MaxTokenLength);
    var expire = DateTime.Now.AddMinutes(EComAppSettings.This.JwtTokenExpireMinutes);
    var unix = new DateTimeOffset(expire).ToUnixTimeSeconds();
    var token = JwtService.Jwt.GenerateToken(dic, expire);
    var response = new Response_User_Login {
      Token = new JwtToken {
        ExpireUnix = unix,
        Token = token,
        RefreshToken = refresh,
        ValidForMinutes = EComAppSettings.This.JwtTokenExpireMinutes
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
    if (!updateResult) return DefResult.DbInternalError(nameof(Authenticate));

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