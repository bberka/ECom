using ECom.Domain.DTOs;
using ECom.Domain.DTOs.AdminDTOs;

namespace ECom.Domain.Interfaces
{
    public interface IAdminJwtAuthenticator 
    {
        public ResultData<AdminLoginResponse> Authenticate(LoginRequest model);

    }
}
