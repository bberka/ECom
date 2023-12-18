using System.Security.Claims;
using ECom.Foundation.DTOs;
using ECom.Foundation.DTOs.Request;

namespace ECom.Foundation.Abstract.Services;

public interface JwtAuthenticator<T> where T : class
{
  public Result<T> Authenticate(Request_Login model);
  public Result<T> Refresh(Request_Token_Refresh model);
  public bool Validate(ValidateTokenRequest model);
  public ClaimsPrincipal? GetClaims(ValidateTokenRequest model);
}