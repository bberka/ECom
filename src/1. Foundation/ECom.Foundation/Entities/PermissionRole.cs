using ECom.Foundation.Enum;

namespace ECom.Foundation.Entities;

[Table("PermissionRoles", Schema = "ECOperation")]
[PrimaryKey(nameof(RoleId), nameof(PermissionType))]
public sealed class PermissionRole
{
  public PermissionRole() { }

  public PermissionRole(string roleId, AdminPermissionType permissionType) {
    RoleId = roleId;
    PermissionType = permissionType;
  }

  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string RoleId { get; set; }

  public AdminPermissionType PermissionType { get; set; }

  public Role Role { get; set; }
}