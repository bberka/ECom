using ECom.Domain.Entities;

namespace ECom.Domain.Abstract;

public interface IUserService
{
  bool UserExists(string email);
  bool UserExists(int id);
  CustomResult<User> GetUser(string email);
  CustomResult<User> GetUser(int id);
  CustomResult<UserDto> LoginUser(LoginRequest model);
  CustomResult RegisterUser(RegisterUserRequest model);
  CustomResult ChangePassword(int userId, ChangePasswordRequest model);
  CustomResult UpdateUser(int userId, UpdateUserRequest model);
}