using ECom.Domain.DTOs;
using ECom.Domain.DTOs.UserDto;

namespace ECom.Domain.Abstract;

public interface IUserService
{
  bool UserExists(string email);
  bool UserExists(int id);
  CustomResult<User> GetUser(string email);
  CustomResult<User> GetUser(int id);
  CustomResult<UserDto> LoginUser(LoginRequest model);
  CustomResult RegisterUser(RegisterUserRequest model);
  CustomResult ChangePassword(ChangePasswordRequest model);
  CustomResult UpdateUser(UpdateUserRequest model);
}