using ECom.Domain.Entities;

namespace ECom.Domain.Abstract;

public interface IUserService
{
  CustomResult<User> GetUser(string email);
  CustomResult<User> GetUser(Guid id);
  List<User> GetUsers();
  CustomResult<UserDto> LoginUser(LoginRequest model);
  CustomResult RegisterUser(RegisterUserRequest model);
  CustomResult ChangePassword(Guid userId, ChangePasswordRequest model);
  CustomResult UpdateUser(Guid userId, UpdateUserRequest model);
}