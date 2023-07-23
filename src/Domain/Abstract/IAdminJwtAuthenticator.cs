using System.Security.Claims;

namespace ECom.Domain.Abstract;

public interface IAdminJwtAuthenticator
{
  public CustomResult<AdminLoginResponse> Authenticate(LoginRequest model);
  public CustomResult<AdminLoginResponse> Refresh(RefreshTokenRequest model);
  public bool Validate(ValidateTokenRequest model);
  public ClaimsPrincipal? GetClaims(ValidateTokenRequest model);
}