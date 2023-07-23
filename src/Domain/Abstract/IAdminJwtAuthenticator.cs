namespace ECom.Domain.Abstract;

public interface IAdminJwtAuthenticator
{
  public CustomResult<AdminLoginResponse> Authenticate(LoginRequest model);
}