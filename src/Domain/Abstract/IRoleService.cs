using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Abstract
{
    public interface IRoleService
    {
        bool HasPermission(int adminId, int permissionId);
        bool HasPermission(int adminId, string permissionName);
        List<RolePermission> GetRoleBinds();
        List<RolePermission> GetAdminRoleBinds(int adminId);
        List<Permission> GetValidPermissionsList();
        List<Permission> GetAdminPermissions(int adminId);
        List<Permission> GetRolePermissions(int roleId);

       
    }
}
