namespace ECom.Domain.Abstract;

public interface IRoleService
{
    List<Role> GetRolesWithPermissions();

    ResultData<Role> GetRole(int roleId);

    ResultData<Role> GetRoleByName(string roleName);
    List<Permission> GetRolePermissions(int roleId); 
 }