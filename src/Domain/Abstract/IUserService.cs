namespace ECom.Domain.Abstract
{
    public interface IUserService
    {
        bool Exists(string email);
        bool Exists(int id);
        ResultData<User> GetUser(string email);
        ResultData<User> GetUser(int id);
        ResultData<User> Login(LoginRequestModel model);
        Result Register(RegisterRequestModel model);
        Result ChangePassword(ChangePasswordRequestModel model);

        Result Update(UpdateUserRequestModel model);
    }

}
