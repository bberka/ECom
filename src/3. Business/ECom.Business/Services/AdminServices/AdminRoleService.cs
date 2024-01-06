using ECom.Foundation.Static;

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
                                   .Include(x => x.Role)
                                   .ThenInclude(x => x.PermissionRoles)
                                   .Any(x => x.Id == adminId && x.Role.PermissionRoles.Any(y => y.PermissionType == permissionId));
    return hasPermission;
  }

  public void EnsurePermission(Guid adminId, AdminPermissionType permissionTypeId) {
    var hasPermission = HasPermission(adminId, permissionTypeId);
    if (!hasPermission) throw new NotAuthorizedException(AuthType.Admin);
  }

  public Result UpdatePermissions(Guid requesterAdminId, string roleId, List<AdminPermissionType> newPermissions) {
    if (string.IsNullOrEmpty(roleId)) return DomResults.x_is_not_found("role");
    var role = _unitOfWork.Roles.Find(roleId);
    if (role is null) return DomResults.x_is_not_found("role");
    role.PermissionRoles = newPermissions.Select(x => new PermissionRole(roleId, x)).ToList();
    _unitOfWork.Roles.Update(role);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(UpdatePermissions));
    return DomResults.x_is_updated_successfully("role");
  }


  public Result AddRole(RoleDto roleDto) {
    roleDto.Id = roleDto.Id.Replace(" ", "");
    var exists = RoleExists(roleDto.Id);
    if (exists) return DomResults.x_already_exists("role");
    var permissions = Enum.GetValues<AdminPermissionType>();
    var notExistsPermissions = roleDto.Permissions.Except(permissions).ToList();
    //TODO: give invalid permissions as param ?
    if (notExistsPermissions.Count != 0) return DomResults.x_is_invalid("permission");
    var role = new Role {
      Id = roleDto.Id,
      PermissionRoles = roleDto.Permissions.Select(x => new PermissionRole(roleDto.Id, x)).ToList()
    };
    _unitOfWork.Roles.Add(role);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(AddRole));
    return DomResults.x_is_added_successfully("role");
  }

  public Result DeleteRole(string roleId) {
    if (roleId == "Owner") return DomResults.x_is_invalid("role");
    var role = _unitOfWork.Roles.Find(roleId);
    if (role is null) return DomResults.x_is_not_found("role");
    var admins = _unitOfWork.Admins.Where(x => x.RoleId == roleId).ToList();
    if (admins.Count > 0) return DomResults.x_can_not_be_deleted_because_of_db_relation("role", "admin");
    _unitOfWork.Roles.Remove(role);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(DeleteRole));
    return DomResults.x_is_deleted_successfully("role");
  }

  public Result SyncOwnerRolePermissions(string valueId) {
    var ownerRole = _unitOfWork.Roles.Find("Owner");
    if (ownerRole is null) return DomResults.x_is_not_found("role");
    var permissions = Enum.GetValues<AdminPermissionType>();
    ownerRole.PermissionRoles = permissions.Select(x => new PermissionRole(ownerRole.Id, x)).ToList();
    _unitOfWork.Roles.Update(ownerRole);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(SyncOwnerRolePermissions));
    return DomResults.x_is_updated_successfully("role");
  }

  public Result<Role> GetRole(string roleId) {
    if (string.IsNullOrEmpty(roleId)) return DomResults.x_is_not_found("role");
    var role = _unitOfWork.Roles.Find(roleId);
    if (role is null) return DomResults.x_is_not_found("role");
    return role;
  }
}