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
        ResultData<Admin> GetAdmin(int id);
        ResultData<Admin> GetAdmin(string email);
        bool Exists(int id);
        bool Exists(string email);
        bool IsValidAdminAccount(int id);
        bool IncreaseFailedPasswordCount(Admin admin);
        ResultData<Admin> Login(LoginRequestModel model);
        bool UpdateSuccessLogin(Admin admin);
        Result AddAdmin(AddAdminRequestModel admin);
        Result ChangePassword(ChangePasswordRequestModel model);
        int GetAdminRoleId(int adminId);
        bool HasPermission(int adminId, int permissionId);
        List<Permission> GetValidPermissions();
        List<Permission> GetInvalidPermissions();
        List<Permission> GetPermissions(int adminId);
        bool IsValidPermission(int permissionId);
        List<Admin> ListOtherAdmins(int adminId);

        Result EnableOrDisableAdmin(int authorAdminId, int adminId);
        Result DeleteAdmin(int authorAdminId, int adminId);
    }
}
