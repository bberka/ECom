using ECom.Domain.DTOs;
using ECom.Domain.DTOs.UserDTOs;

namespace ECom.Domain.Abstract;

public interface IUserJwtAuthenticator
{
  public ResultData<UserLoginResponse> Authenticate(LoginRequest model);
}