
using ECom.Domain.DTOs;
using ECom.Domain.DTOs.UserDTOs;

namespace ECom.Domain.Interfaces
{
    public interface IUserJwtAuthenticator 
    {
        public ResultData<UserLoginResponse> Authenticate(LoginRequest model);
    }
}
