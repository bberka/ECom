using ECom.Domain.Entities;

namespace ECom.Domain.Abstract;

public interface IRoleService
{
  List<Role> GetRoles();
  CustomResult<Role> GetRole(string roleId);
  bool RoleExists(string roleId);
}