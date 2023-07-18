using ECom.Domain.DTOs;
using ECom.Domain.DTOs.UserDto;

namespace ECom.Domain.Abstract;

public interface IUserJwtAuthenticator
{
  public CustomResult<UserLoginResponse> Authenticate(LoginRequest model);
}