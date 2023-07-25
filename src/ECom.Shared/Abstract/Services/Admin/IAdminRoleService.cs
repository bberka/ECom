using ECom.Shared.Entities;

namespace ECom.Shared.Abstract.Services.Admin;

public interface IAdminRoleService
{
    List<Role> GetRoles();
    List<Permission> GetPermissions();
    bool RoleExists(string roleId);
    bool HasPermission(Guid adminId, string permissionId);
    CustomResult UpdatePermissions(Guid requesterAdminId, string roleId, List<string> permissions);
    CustomResult AddRole(AddRoleRequest role);
    CustomResult DeleteRole(string roleId);

}