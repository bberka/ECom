using ECom.Domain.DTOs;
using ECom.Domain.DTOs.UserDTOs;

namespace ECom.Domain.Abstract;

public interface IUserService
{
  bool Exists(string email);
  bool Exists(int id);
  CustomResult<User> GetUser(string email);
  CustomResult<User> GetUser(int id);
  CustomResult<UserDto> Login(LoginRequest model);
  CustomResult Register(RegisterUserRequest model);
  CustomResult ChangePassword(ChangePasswordRequest model);
  CustomResult Update(UpdateUserRequest model);
}