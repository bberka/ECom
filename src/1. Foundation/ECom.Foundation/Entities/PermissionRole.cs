using ECom.Foundation.Static;

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

  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string RoleId { get; set; }

  public AdminPermissionType PermissionType { get; set; }

  public Role Role { get; set; }
}