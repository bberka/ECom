using ECom.Domain.Results;

namespace ECom.Application.Services;

public class RoleService : IRoleService
{
    private readonly IEfEntityRepository<Role> _roleRepo;
    private readonly IEfEntityRepository<RolePermission> _rolePermissionRepo;

    public RoleService(
        IEfEntityRepository<Role> roleRepo,
        IEfEntityRepository<RolePermission> rolePermissionRepo)
    {
        _roleRepo = roleRepo;
        _rolePermissionRepo = rolePermissionRepo;
    }

    public List<Role> GetRolesWithPermissions()
    {
        return _roleRepo
            .Get()
            .Include(x => x.Permissions)
            .ToList();
    }

    public ResultData<Role> GetRole(int roleId)
    {
        var role = _roleRepo.Find(roleId);
        if (role is null) return DomainResult.Role.NotFoundResult(1);
        return role;
    }

    public ResultData<Role> GetRoleByName(string roleName)
    {
        var role = _roleRepo.GetFirstOrDefault(x => x.Name == roleName);
        if (role is null) return DomainResult.Role.NotFoundResult(1);
        return role;
    }


    public List<Permission> GetRolePermissions(int roleId)
    {
        var role = _roleRepo
            .Get(x => x.Id == roleId)
            .Include(x => x.Permissions)
            .FirstOrDefault();
        if (role is null) return new();
        return role.Permissions;
    }
}