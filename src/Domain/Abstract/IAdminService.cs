using ECom.Domain.Entities;

namespace ECom.Domain.Abstract;

public interface IAdminService
{
  List<Admin> GetAdmins();
  CustomResult<Admin> GetAdmin(int id);
  CustomResult<Admin> GetAdmin(string email);
  CustomResult<AdminDto> GetAdminDto(int id);
  CustomResult<AdminDto> GetAdminDto(string email);
  bool AdminExists(int id);
  bool AdminExists(string email);
  bool IsValidAdminAccount(int id);
  CustomResult<AdminDto> AdminLogin(LoginRequest model);
  CustomResult AddAdmin(AddAdminRequest admin);
  CustomResult ChangePassword(int authId, ChangePasswordRequest model);

  int GetAdminRoleId(int adminId);

  //bool HasPermission(int adminId, int permissionId);
  List<Permission> GetValidPermissions();
  List<Permission> GetInvalidPermissions();
  bool IsValidPermission(int permissionId);
  List<AdminDto> ListOtherAdmins(int adminId);
  CustomResult DeleteAdmin(int authorAdminId, int adminId);
  CustomResult UpdateAdmin(int authorAdminId, UpdateAdminAccountRequest request);
  CustomResult RecoverAdmin(int authorAdminId, int id);
}