
namespace ECom.Domain.Interfaces
{
    public interface IUserJwtAuthenticator 
    {
        public ResultData<UserLoginResponse> Authenticate(LoginRequest model);
    }
}
