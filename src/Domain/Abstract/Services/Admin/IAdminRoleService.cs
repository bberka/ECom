using ECom.Domain.Entities;

namespace ECom.Domain.Abstract.Services.Admin;

public interface IAdminRoleService
{
    List<Role> GetRoles();
    List<Permission> GetPermissions();
    bool RoleExists(string roleId);
    bool HasPermission(Guid adminId, string permissionId);
    CustomResult UpdatePermissions(Guid requesterAdminId, string roleId, List<string> permissions);
}