using ECom.Foundation.Abstract.Services.Base;
using ECom.Foundation.DTOs;
using ECom.Foundation.DTOs.Request;

namespace ECom.Foundation.Abstract.Services.User;

public interface IUserAccountService : IAccountService<UserDto>
{
  Result<Entities.User> GetUser(string email);
  Result<Entities.User> GetUser(Guid id);
  List<Entities.User> GetUsers();
  Result RegisterUser(Request_User_Register model);
  Result UpdateUser(Guid userId, Request_User_Update model);
}