using System.Data;
using ECom.Domain.Aspects;
using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Admin;
using ECom.Shared.Constants;
using ECom.Shared.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace ECom.Application.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminRoleService : IAdminRoleService
{
  protected readonly IUnitOfWork UnitOfWork;

  public AdminRoleService(IUnitOfWork unitOfWork) {
    UnitOfWork = unitOfWork;
  }

  public List<AdminPermission> GetPermissions() {
    return Enum.GetValues<AdminPermission>().ToList();
  }

  public List<string> GetPermissionStrings() {
    var permissions = Enum.GetNames(typeof(AdminPermission)).ToList();
    return permissions;
  }

  public List<RoleDto> GetRoles() {
    return UnitOfWork.Roles
      .Select(x => new RoleDto(x))
      //.Join(UnitOfWork.Admins,
      //  x => x.Id,
      //  x => x.RoleId,
      //  (role, admin) => new RoleDto(role.Id,role.PermissionRoles) {
      //    AdminCount = UnitOfWork.Admins.Count(x => x.RoleId == role.Id),
      //  })
      .ToList();
  }

  public CustomResult<Role> GetRole(string roleId) {
    if (string.IsNullOrEmpty(roleId)) return DomainResult.NotFound(Role.LocKey);
    var role = UnitOfWork.Roles.Find(roleId);
    if (role is null) return DomainResult.NotFound(Role.LocKey);
    return role;
  }


  public bool RoleExists(string roleId) {
    if (string.IsNullOrEmpty(roleId)) return false;
    return UnitOfWork.Roles.Any(x => x.Id == roleId);
  }

  public bool HasPermission(Guid adminId, AdminPermission permissionId) {
    var hasPermission = UnitOfWork.Admins
      .Any(x => x.Id == adminId && x.Role.PermissionRoles.Any(y => y.Permission == permissionId));
    return hasPermission;
  }

  public CustomResult UpdatePermissions(Guid requesterAdminId, string roleId, List<AdminPermission> newPermissions) {
    if (string.IsNullOrEmpty(roleId)) return DomainResult.NotFound(Role.LocKey);
    var role = UnitOfWork.Roles.Find(roleId);
    if (role is null) return DomainResult.NotFound(Role.LocKey);
    role.PermissionRoles = newPermissions.Select(x => new PermissionRole(roleId,x)).ToList();
    UnitOfWork.Roles.Update(role);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdatePermissions));
    return DomainResult.OkUpdated(Role.LocKey);
  }


  public CustomResult AddRole(RoleDto roleDto) {
    roleDto.Id = roleDto.Id.Replace(" ", "");
    var exists = RoleExists(roleDto.Id);
    if (exists) return DomainResult.AlreadyExists(Role.LocKey);
    var permissions = Enum.GetValues<AdminPermission>();
    var notExistsPermissions = roleDto.Permissions.Except(permissions).ToList();
    //TODO: give invalid permissions as param ?
    if (notExistsPermissions.Count != 0) return DomainResult.Invalid("permission");
    var role = new Role {
      Id = roleDto.Id,
      PermissionRoles = roleDto.Permissions.Select(x => new PermissionRole(roleDto.Id,x)).ToList()
    };
    UnitOfWork.Roles.Add(role);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddRole));
    return DomainResult.OkAdded(Role.LocKey);
  }

  public CustomResult DeleteRole(string roleId) {
    if (roleId == "Owner") return DomainResult.Invalid(nameof(roleId));
    var role = UnitOfWork.Roles.Find(roleId);
    if (role is null) return DomainResult.NotFound(Role.LocKey);
    var admins = UnitOfWork.Admins.Where(x => x.RoleId == roleId).ToList();
    if (admins.Count > 0) return DomainResult.CanNotDeleteBcRelation(Role.LocKey, nameof(Admin));
    UnitOfWork.Roles.Remove(role);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteRole));
    return DomainResult.OkDeleted(Role.LocKey);
  }
}