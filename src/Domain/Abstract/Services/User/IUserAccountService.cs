using ECom.Domain.Abstract.Services.Base;
using ECom.Domain.Entities;

namespace ECom.Domain.Abstract.Services.User;

public partial interface IUserAccountService : IAccountService<UserDto>
{
    CustomResult<Entities.User> GetUser(string email);
    CustomResult<Entities.User> GetUser(Guid id);
    List<Entities.User> GetUsers();
    CustomResult RegisterUser(RegisterUserRequest model);
    CustomResult UpdateUser(Guid userId, UpdateUserRequest model);
}