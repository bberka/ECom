namespace ECom.Domain.Abstract
{
    public interface IUserService
    {
        bool Exists(string email);
        bool Exists(int id);
        ResultData<User> GetUser(string email);
        ResultData<User> GetUser(int id);
        bool IncreaseFailedPasswordCount(int userId);
        bool IncreaseFailedPasswordCount(User user);
        ResultData<User> Login(LoginRequestModel model);
        Result Register(RegisterRequestModel model);
        Result ChangePassword(ChangePasswordRequestModel model);
        bool UpdateSuccessLogin(User user);
    }
}
