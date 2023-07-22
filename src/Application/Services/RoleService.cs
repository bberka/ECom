using ECom.Domain.Entities;

namespace ECom.Application.Services;

public class RoleService : IRoleService
{
  private readonly IUnitOfWork _unitOfWork;

  public RoleService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public List<Permission> GetPermissions() {
    return _unitOfWork.PermissionRepository
      .GetAll()
      .ToList();
  }

  public List<Role> GetRoles() {
    return _unitOfWork.RoleRepository
      .GetAll()
      //.Include(x => x.PermissionRoles)
      .ToList();
  }

  public CustomResult<Role> GetRole(string roleId) {
    if (string.IsNullOrEmpty(roleId)) return DomainResult.NotFound(nameof(Role));
    var role = _unitOfWork.RoleRepository.Find(roleId);
    if (role is null) return DomainResult.NotFound(nameof(Role));
    return role;
  }


  public bool RoleExists(string roleId) {
    if (string.IsNullOrEmpty(roleId)) return false;
    return _unitOfWork.RoleRepository.Any(x => x.Id == roleId);
  }

  public CustomResult UpdatePermissions(string roleId, List<string> permissions) {
    if (string.IsNullOrEmpty(roleId)) return DomainResult.NotFound(nameof(Role));
    var role = _unitOfWork.RoleRepository.Find(roleId);
    if (role is null) return DomainResult.NotFound(nameof(Role));
    var permissionRoles = _unitOfWork.PermissionRoleRepository.Get(x => x.RoleId == roleId)
      .ToList();
    var permissionsToAdd = permissions
      .Where(x => permissionRoles.All(y => y.PermissionId != x))
      .Select(x => new PermissionRole { PermissionId = x, RoleId = roleId })
      .ToList() ?? new();
    var permissionsToRemove = permissionRoles
      .Where(x => permissions.All(y => y != x.PermissionId))
      .ToList() ?? new();
    var isNeedUpdate = permissionsToAdd.Any() || permissionsToRemove.Any();
    if (!isNeedUpdate) return DomainResult.OkNotChanged(nameof(Role));
    if (permissionsToRemove.Count > 0)
      _unitOfWork.PermissionRoleRepository.DeleteRange(permissionsToRemove);
    if (permissionsToAdd.Count > 0)
      _unitOfWork.PermissionRoleRepository.InsertRange(permissionsToAdd);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdatePermissions));
    return DomainResult.OkUpdated(nameof(Role));
  }
}