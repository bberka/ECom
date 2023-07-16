using ECom.Domain.DTOs;
using ECom.Domain.DTOs.AdminDTOs;

namespace ECom.Domain.Abstract;

public interface IAdminService
{
  List<Admin> GetAdmins();
  CustomResult<Admin> GetAdmin(int id);
  CustomResult<Admin> GetAdmin(string email);
  CustomResult<AdminDto> GetAdminDto(int id);
  CustomResult<AdminDto> GetAdminDto(string email);
  bool Exists(int id);
  bool Exists(string email);
  bool IsValidAdminAccount(int id);
  CustomResult<AdminDto> Login(LoginRequest model);
  CustomResult AddAdmin(AddAdminRequest admin);
  CustomResult ChangePassword(ChangePasswordRequest model);

  int GetAdminRoleId(int adminId);

  //bool HasPermission(int adminId, int permissionId);
  List<Permission> GetValidPermissions();
  List<Permission> GetInvalidPermissions();
  bool IsValidPermission(int permissionId);
  List<Admin> ListOtherAdmins(int adminId);
  CustomResult EnableAdmin(int authorAdminId, int adminId);
  CustomResult DisableAdmin(int authorAdminId, int adminId);
  CustomResult DeleteAdmin(int authorAdminId, int adminId);
}