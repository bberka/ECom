namespace ECom.Domain.Abstract;

public interface IRoleService
{
  List<Role> GetRolesWithPermissions();

  CustomResult<Role> GetRole(int roleId);

  CustomResult<Role> GetRoleByName(string roleName);
  HashSet<Permission> GetRolePermissions(int roleId);
}