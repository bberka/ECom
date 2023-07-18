using ECom.Domain;
using ECom.Domain.DTOs.RoleDTOs;

namespace ECom.Application.Services;

public class RoleService : IRoleService
{
  private readonly IUnitOfWork _unitOfWork;

  public RoleService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public List<RoleDto> GetRolesWithPermissions() {
    return _unitOfWork.RoleRepository
      .Get()
      .Select(x => new RoleDto(x))
      .ToList();
  }

  public CustomResult<Role> GetRole(int roleId) {
    var role = _unitOfWork.RoleRepository.GetById(roleId);
    if (role is null) return DomainResult.NotFound(nameof(Role));
    return role;
  }

  public CustomResult<Role> GetRoleByName(string roleName) {
    var role = _unitOfWork.RoleRepository.GetFirstOrDefault(x => x.Name == roleName);
    if (role is null) return DomainResult.NotFound(nameof(Role));
    return role;
  }


  public HashSet<Permission> GetRolePermissions(int roleId) {
    var role = _unitOfWork.RoleRepository
      .Get(x => x.Id == roleId)
      //.Include(x => x.Permissions)
      .FirstOrDefault();
    if (role is null) return new HashSet<Permission>();
    //return role.Permissions;
    return new HashSet<Permission>();
  }
}