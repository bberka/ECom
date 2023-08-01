using ECom.Shared.Abstract.Services.Base;

namespace ECom.Shared.Abstract.Services.User;

public partial interface IUserAccountService : IAccountService<UserDto>
{
    CustomResult<Shared.Entities.User> GetUser(string email);
    CustomResult<Shared.Entities.User> GetUser(Guid id);
    List<Shared.Entities.User> GetUsers();
    CustomResult RegisterUser(RegisterUserRequestDto model);
    CustomResult UpdateUser(Guid userId, UpdateUserRequest model);
}