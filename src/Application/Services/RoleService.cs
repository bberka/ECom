using ECom.Domain.Entities;

namespace ECom.Application.Services;

public class RoleService : IRoleService
{
  private readonly IUnitOfWork _unitOfWork;

  public RoleService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public List<Role> GetRoles() {
    return _unitOfWork.RoleRepository
      .Get()
      .Include(x => x.PermissionRoles)
      .ToList();
  }

  public CustomResult<Role> GetRole(string roleId) {
    if (string.IsNullOrEmpty(roleId)) return DomainResult.NotFound(nameof(Role));
    var role = _unitOfWork.RoleRepository.GetById(roleId);
    if (role is null) return DomainResult.NotFound(nameof(Role));
    return role;
  }


  public bool RoleExists(string roleId) {
    if(string.IsNullOrEmpty(roleId)) return false;
    return _unitOfWork.RoleRepository.Any(x => x.Id == roleId);
  }
}