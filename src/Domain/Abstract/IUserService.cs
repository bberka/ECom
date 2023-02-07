namespace ECom.Domain.Abstract
{
    public interface IUserService
    {
        void CheckExistsOrThrow(int id);
        void CheckExistsOrThrow(uint id);
        bool Exists(string email);
        bool Exists(int id);
        User? GetUser(string email);
        User? GetUser(int id);
        User GetUserOrThrow(string email);
        User GetUserOrThrow(int id);
        bool IncreaseFailedPasswordCount(int userId);
        bool IncreaseFailedPasswordCount(User user);
        ResultData<User> Login(LoginRequestModel model);
        Result Register(RegisterRequestModel model);
        Result ChangePassword(ChangePasswordRequestModel model);
        bool UpdateSuccessLogin(User user);
    }
}
