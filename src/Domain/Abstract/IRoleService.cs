using ECom.Domain.Entities;

namespace ECom.Domain.Abstract;

public interface IRoleService
{
  List<Role> GetRoles();
  List<Permission> GetPermissions();
  CustomResult<Role> GetRole(string roleId);
  bool RoleExists(string roleId);
  CustomResult UpdatePermissions(string roleId, List<string> permissions);
}