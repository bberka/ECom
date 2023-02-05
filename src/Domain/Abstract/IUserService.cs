
using ECom.Domain.ApiModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Abstract
{
    public interface IUserService
    {
        void CheckExistsOrThrow(int id);
        void CheckExistsOrThrow(uint id);
        bool Exists(string email);
        User? GetUser(string email);
        User? GetUser(int id);
        User GetUserOrThrow(string email);
        User GetUserOrThrow(int id);
        bool IncreaseFailedPasswordCount(int userId);
        bool IncreaseFailedPasswordCount(User user);
        User Login(LoginRequestModel model);
        Result Register(RegisterRequestModel model);
        bool UpdateSuccessLogin(User user);
    }
}
