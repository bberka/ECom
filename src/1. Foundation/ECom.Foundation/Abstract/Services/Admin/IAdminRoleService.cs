using ECom.Foundation.DTOs;
using ECom.Foundation.Enum;

namespace ECom.Foundation.Abstract.Services.Admin;

public interface IAdminRoleService
{
  List<RoleDto> GetRoles();
  List<AdminPermissionType> GetPermissions();
  List<string> GetPermissionStrings();
  bool RoleExists(string roleId);
  bool HasPermission(Guid adminId, AdminPermissionType permissionTypeId);
  Result UpdatePermissions(Guid requesterAdminId, string roleId, List<AdminPermissionType> permissions);
  Result AddRole(RoleDto role);
  Result DeleteRole(string roleId);
  Result SyncOwnerRolePermissions(string valueId);
}