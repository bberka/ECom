namespace ECom.Domain.Abstract;

public interface IRoleService
{
  List<Role> GetRolesWithPermissions();

  ResultData<Role> GetRole(int roleId);

  ResultData<Role> GetRoleByName(string roleName);
  HashSet<Permission> GetRolePermissions(int roleId);
}