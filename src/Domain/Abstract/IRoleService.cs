using ECom.Domain.DTOs.RoleDTOs;

namespace ECom.Domain.Abstract;

public interface IRoleService
{
  List<RoleDto> GetRolesWithPermissions();

  CustomResult<Role> GetRole(int roleId);

  CustomResult<Role> GetRoleByName(string roleName);
  HashSet<Permission> GetRolePermissions(int roleId);
}