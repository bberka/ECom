using ECom.Domain.Entities;

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
      .Select(x => Role.ToDto(x))
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

  public bool RoleExists(int roleId) {
    if (roleId < 1) return false;
    return _unitOfWork.RoleRepository.Any(x => x.Id == roleId);
  }
}