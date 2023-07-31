using System.Data;
using ECom.Domain.Aspects;
using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Admin;
using ECom.Shared.Entities;

namespace ECom.Application.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminRoleService : IAdminRoleService
{
  protected readonly IUnitOfWork UnitOfWork;

  public AdminRoleService(IUnitOfWork unitOfWork) {
    UnitOfWork = unitOfWork;
  }

  public List<Permission> GetPermissions() {
    return UnitOfWork.PermissionRepository

      .ToList();
  }

  public List<Role> GetRoles() {
    return UnitOfWork.RoleRepository
      .Include(x => x.Permissions)
      .Join(UnitOfWork.AdminRepository,
        x => x.Id,
        x => x.RoleId,
        (role, admin) => new Role {
          Id = role.Id,
          AdminCount = UnitOfWork.AdminRepository.Count(x => x.RoleId == role.Id),
          Permissions = role.Permissions
        })
      .ToList();
  }

  public CustomResult<Role> GetRole(string roleId) {
    if (string.IsNullOrEmpty(roleId)) return DomainResult.NotFound(nameof(Role));
    var role = UnitOfWork.RoleRepository.Find(roleId);
    if (role is null) return DomainResult.NotFound(nameof(Role));
    return role;
  }


  public bool RoleExists(string roleId) {
    if (string.IsNullOrEmpty(roleId)) return false;
    return UnitOfWork.RoleRepository.Any(x => x.Id == roleId);
  }

  public bool HasPermission(Guid adminId, string permissionId) {
    var hasPermission = UnitOfWork.AdminRepository
      .Any(x => x.Id == adminId && x.Role.Permissions.Any(y => y.Id == permissionId));
    return hasPermission;
  }

  public CustomResult UpdatePermissions(Guid requesterAdminId, string roleId, List<string> permissions) {
    if (string.IsNullOrEmpty(roleId)) return DomainResult.NotFound(nameof(Role));
    var role = UnitOfWork.RoleRepository.Find(roleId);
    if (role is null) return DomainResult.NotFound(nameof(Role));
    role.Permissions = permissions.Select(x => new Permission() {
      Id = x
    }).ToList();
    UnitOfWork.RoleRepository.Update(role);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdatePermissions));
    return DomainResult.OkUpdated(nameof(Role));
  }


  public CustomResult AddRole(AddRoleRequest roleRequest) {
    roleRequest.RoleName = roleRequest.RoleName.Replace(" ", "");
    var exists = RoleExists(roleRequest.RoleName);
    if (exists) return DomainResult.AlreadyExists(nameof(Role));
    var dbPermissionList = UnitOfWork.PermissionRepository

      .Select(x => x.Id)
      .ToList();
    var notExistsPermissions = roleRequest.Permissions.Except(dbPermissionList).ToList();
    //TODO: give invalid permissions as param ?
    if (notExistsPermissions.Count != 0) return DomainResult.Invalid(nameof(Permission));
    var role = new Role {
      Id = roleRequest.RoleName,
      Permissions = roleRequest.Permissions.Select(x => new Permission() { Id = x }).ToList()
    };
    UnitOfWork.RoleRepository.Add(role);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddRole));
    return DomainResult.OkAdded(nameof(Role));
  }

  public CustomResult DeleteRole(string roleId) {
    if (roleId == "Owner") return DomainResult.Invalid(nameof(roleId));
    var role = UnitOfWork.RoleRepository.Find(roleId);
    if (role is null) return DomainResult.NotFound(nameof(Role));
    var admins = UnitOfWork.AdminRepository.Where(x => x.RoleId == roleId).ToList();
    if (admins.Count > 0) return DomainResult.CanNotDeleteBcRelation(nameof(Role), nameof(Admin));
    UnitOfWork.RoleRepository.Remove(role);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteRole));
    return DomainResult.OkDeleted(nameof(Role));
  }
}