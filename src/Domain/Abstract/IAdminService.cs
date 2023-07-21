using ECom.Domain.Entities;

namespace ECom.Domain.Abstract;

public interface IAdminService
{
  List<AdminDto> GetAdmins();
  CustomResult<Admin> GetAdmin(Guid id);
  CustomResult<Admin> GetAdmin(string email);
  CustomResult<AdminDto> GetAdminDto(Guid id);
  CustomResult<AdminDto> GetAdminDto(string email);
  bool AdminExists(Guid id);
  bool AdminExists(string email);
  bool IsValidAdminAccount(Guid id);
  CustomResult<AdminDto> AdminLogin(LoginRequest model);
  CustomResult AddAdmin(AddAdminRequest admin);
  CustomResult ChangePassword(Guid authId, ChangePasswordRequest model);
  string? GetAdminRoleId(Guid userId);

  //bool HasPermission(Guid userId, int permissionId);
  List<Permission> GetValidPermissions();
  List<Permission> GetInvalidPermissions();
  bool IsValidPermission(string permissionId);
  List<AdminDto> ListOtherAdmins(Guid userId);
  CustomResult DeleteAdmin(Guid authorAdminId, Guid userId);
  CustomResult UpdateAdmin(Guid authorAdminId, UpdateAdminAccountRequest request);
  CustomResult RecoverAdmin(Guid authorAdminId, Guid id);
}