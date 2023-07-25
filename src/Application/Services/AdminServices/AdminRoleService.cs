using ECom.Domain.Abstract.Services.Admin;
using ECom.Domain.Aspects;
using ECom.Domain.Entities;

namespace ECom.Application.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminRoleService : IAdminRoleService
{
    protected readonly IUnitOfWork UnitOfWork;

    public AdminRoleService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public List<Permission> GetPermissions()
    {
        return UnitOfWork.PermissionRepository
          .GetAll()
          .ToList();
    }

    public List<Role> GetRoles()
    {
        return UnitOfWork.RoleRepository
          .GetAll()
          //.Include(x => x.PermissionRoles)
          .ToList();
    }

    public CustomResult<Role> GetRole(string roleId)
    {
        if (string.IsNullOrEmpty(roleId)) return DomainResult.NotFound(nameof(Role));
        var role = UnitOfWork.RoleRepository.Find(roleId);
        if (role is null) return DomainResult.NotFound(nameof(Role));
        return role;
    }


    public bool RoleExists(string roleId)
    {
        if (string.IsNullOrEmpty(roleId)) return false;
        return UnitOfWork.RoleRepository.Any(x => x.Id == roleId);
    }

    public bool HasPermission(Guid adminId, string permissionId)
    {
        var hasPermission = UnitOfWork.AdminRepository
          .Any(x => x.Id == adminId && x.Role.PermissionRoles.Any(y => y.PermissionId == permissionId));
        return hasPermission;
    }

    public CustomResult UpdatePermissions(Guid requesterAdminId, string roleId, List<string> permissions)
    {
        if (string.IsNullOrEmpty(roleId)) return DomainResult.NotFound(nameof(Role));
        var role = UnitOfWork.RoleRepository.Find(roleId);
        if (role is null) return DomainResult.NotFound(nameof(Role));
        var permissionRoles = UnitOfWork.PermissionRoleRepository.Get(x => x.RoleId == roleId)
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
            UnitOfWork.PermissionRoleRepository.DeleteRange(permissionsToRemove);
        if (permissionsToAdd.Count > 0)
            UnitOfWork.PermissionRoleRepository.InsertRange(permissionsToAdd);
        var res = UnitOfWork.Save();
        if (!res) return DomainResult.DbInternalError(nameof(UpdatePermissions));
        return DomainResult.OkUpdated(nameof(Role));
    }
}