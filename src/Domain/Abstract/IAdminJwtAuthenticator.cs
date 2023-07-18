using ECom.Domain.DTOs;
using ECom.Domain.DTOs.AdminDto;

namespace ECom.Domain.Abstract;

public interface IAdminJwtAuthenticator
{
  public CustomResult<AdminLoginResponse> Authenticate(LoginRequest model);
}