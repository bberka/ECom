using ECom.Shared.Entities;

namespace ECom.Shared.Abstract.Services.Admin;

public interface IAdminRoleService
{
    List<RoleDto> GetRoles();
    List<AdminPermission> GetPermissions();
    List<string> GetPermissionStrings();
    bool RoleExists(string roleId);
    bool HasPermission(Guid adminId, AdminPermission permissionId);
    CustomResult UpdatePermissions(Guid requesterAdminId, string roleId, List<AdminPermission> permissions);
    CustomResult AddRole(RoleDto role);
    CustomResult DeleteRole(string roleId);

}