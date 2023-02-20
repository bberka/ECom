using ECom.Domain.Results;

namespace ECom.Application.Services;

public class RoleService : IRoleService
{
    private readonly IUnitOfWork _unitOfWork;

    public RoleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public List<Role> GetRolesWithPermissions()
    {
        return _unitOfWork.RoleRepository
            .Get()
            //.Include(x => x.Permissions)
            .ToList();
    }

    public ResultData<Role> GetRole(int roleId)
    {
        var role = _unitOfWork.RoleRepository.Find(roleId);
        if (role is null) return DomainResult.Role.NotFoundResult(1);
        return role;
    }

    public ResultData<Role> GetRoleByName(string roleName)
    {
        var role = _unitOfWork.RoleRepository.GetFirstOrDefault(x => x.Name == roleName);
        if (role is null) return DomainResult.Role.NotFoundResult(1);
        return role;
    }


    public HashSet<Permission> GetRolePermissions(int roleId)
    {
        var role = _unitOfWork.RoleRepository
            .Get(x => x.Id == roleId)
            //.Include(x => x.Permissions)
            .FirstOrDefault();
        if (role is null) return new();
        //return role.Permissions;
        return new();
    }
}