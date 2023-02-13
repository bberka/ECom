namespace ECom.Domain.Interfaces
{
    public interface IAdminJwtAuthenticator 
    {
        public ResultData<AdminLoginResponse> Authenticate(LoginRequest model);

    }
}
