using ECom.Domain.DTOs;
using ECom.Domain.DTOs.AdminDTOs;

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
        ResultData<AdminDto> Login(LoginRequest model);
        Result AddAdmin(AddAdminRequest admin);
        Result ChangePassword(ChangePasswordRequest model);
        int GetAdminRoleId(int adminId);
        //bool HasPermission(int adminId, int permissionId);
        List<Permission> GetValidPermissions();
        List<Permission> GetInvalidPermissions();
        bool IsValidPermission(int permissionId);
        List<Admin> ListOtherAdmins(int adminId);
        Result EnableOrDisableAdmin(int authorAdminId, int adminId);
        Result DeleteAdmin(int authorAdminId, int adminId);
    }
}
