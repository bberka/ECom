namespace ECom.Business.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminRoleService : IAdminRoleService
{
  private readonly IUnitOfWork _unitOfWork;

  public AdminRoleService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public List<AdminPermissionType> GetPermissions() {
    return Enum.GetValues<AdminPermissionType>().ToList();
  }

  public List<string> GetPermissionStrings() {
    var permissions = Enum.GetNames(typeof(AdminPermissionType)).ToList();
    return permissions;
  }

  public List<RoleDto> GetRoles() {
    return _unitOfWork.Roles
                      .Select(x => new RoleDto(x))
                      //.Join(_unitOfWork.Admins,
                      //  x => x.Id,
                      //  x => x.RoleId,
                      //  (role, admin) => new RoleDto(role.Id,role.PermissionRoles) {
                      //    AdminCount = _unitOfWork.Admins.Count(x => x.RoleId == role.Id),
                      //  })
                      .ToList();
  }


  public bool RoleExists(string roleId) {
    if (string.IsNullOrEmpty(roleId)) return false;
    return _unitOfWork.Roles.Any(x => x.Id == roleId);
  }

  public bool HasPermission(Guid adminId, AdminPermissionType permissionId) {
    var hasPermission = _unitOfWork.Admins
                                   .Any(x => x.Id == adminId && x.Role.PermissionRoles.Any(y => y.PermissionType == permissionId));
    return hasPermission;
  }

  public Result UpdatePermissions(Guid requesterAdminId, string roleId, List<AdminPermissionType> newPermissions) {
    if (string.IsNullOrEmpty(roleId)) return DefResult.NotFound(Role.LocKey);
    var role = _unitOfWork.Roles.Find(roleId);
    if (role is null) return DefResult.NotFound(Role.LocKey);
    role.PermissionRoles = newPermissions.Select(x => new PermissionRole(roleId, x)).ToList();
    _unitOfWork.Roles.Update(role);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(UpdatePermissions));
    return DefResult.OkUpdated(Role.LocKey);
  }


  public Result AddRole(RoleDto roleDto) {
    roleDto.Id = roleDto.Id.Replace(" ", "");
    var exists = RoleExists(roleDto.Id);
    if (exists) return DefResult.AlreadyExists(Role.LocKey);
    var permissions = Enum.GetValues<AdminPermissionType>();
    var notExistsPermissions = roleDto.Permissions.Except(permissions).ToList();
    //TODO: give invalid permissions as param ?
    if (notExistsPermissions.Count != 0) return DefResult.Invalid("permission");
    var role = new Role {
      Id = roleDto.Id,
      PermissionRoles = roleDto.Permissions.Select(x => new PermissionRole(roleDto.Id, x)).ToList()
    };
    _unitOfWork.Roles.Add(role);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(AddRole));
    return DefResult.OkAdded(Role.LocKey);
  }

  public Result DeleteRole(string roleId) {
    if (roleId == "Owner") return DefResult.Invalid(nameof(roleId));
    var role = _unitOfWork.Roles.Find(roleId);
    if (role is null) return DefResult.NotFound(Role.LocKey);
    var admins = _unitOfWork.Admins.Where(x => x.RoleId == roleId).ToList();
    if (admins.Count > 0) return DefResult.CanNotDeleteBecauseOfDbRelation(Role.LocKey, nameof(Admin));
    _unitOfWork.Roles.Remove(role);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(DeleteRole));
    return DefResult.OkDeleted(Role.LocKey);
  }

  public Result SyncOwnerRolePermissions(string valueId) {
    var ownerRole = _unitOfWork.Roles.Find("Owner");
    if (ownerRole is null) return DefResult.NotFound(Role.LocKey);
    var permissions = Enum.GetValues<AdminPermissionType>();
    ownerRole.PermissionRoles = permissions.Select(x => new PermissionRole(ownerRole.Id, x)).ToList();
    _unitOfWork.Roles.Update(ownerRole);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(SyncOwnerRolePermissions));
    return DefResult.OkUpdated(Role.LocKey);
  }

  public Result<Role> GetRole(string roleId) {
    if (string.IsNullOrEmpty(roleId)) return DefResult.NotFound(Role.LocKey);
    var role = _unitOfWork.Roles.Find(roleId);
    if (role is null) return DefResult.NotFound(Role.LocKey);
    return role;
  }
}