namespace ECom.Shared.Abstract.Services.User;

public interface IUserJwtAuthenticator
{
    public CustomResult<UserLoginResponse> Authenticate(LoginRequest model);
}