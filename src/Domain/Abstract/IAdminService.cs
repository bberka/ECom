using ECom.Domain.ApiModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetAdmins();
        Admin? GetAdmin(int id);
        Admin GetAdminOrThrow(int id);
        Admin GetValidAdminOrThrow(int id);
        void CheckValidAdminOrThrow(int id);
        bool Exists(int id);
        bool Exists(string email);
        Admin? GetAdmin(string email);
        bool IncreaseFailedPasswordCount(Admin admin);
        ResultData<Admin> Login(LoginRequestModel model);
        bool UpdateSuccessLogin(Admin admin);
        Result AddAdmin(AddAdminRequestModel admin);
        Result ChangePassword(ChangePasswordRequestModel model);
        int GetAdminRoleId(int adminId);
    }
}
