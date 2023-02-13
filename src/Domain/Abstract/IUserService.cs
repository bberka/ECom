using ECom.Domain.DTOs.Response;

namespace ECom.Domain.Abstract
{
    public interface IUserService
    {
        bool Exists(string email);
        bool Exists(int id);
        ResultData<User> GetUser(string email);
        ResultData<User> GetUser(int id);
        ResultData<UserDto> Login(LoginRequest model);
        Result Register(RegisterRequest model);
        Result ChangePassword(ChangePasswordRequest model);
        Result Update(UpdateUserRequest model);
    }

}
