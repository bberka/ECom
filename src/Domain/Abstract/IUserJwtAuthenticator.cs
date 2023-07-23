namespace ECom.Domain.Abstract;

public interface IUserJwtAuthenticator
{
  public CustomResult<UserLoginResponse> Authenticate(LoginRequest model);
}