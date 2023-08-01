using ECom.Shared.Resources;

namespace ECom.Shared.Entities;

[Table("PermissionRoles", Schema = "ECOperation")]
[PrimaryKey(nameof(RoleId), nameof(Permission))]
public sealed class PermissionRole
{
  public PermissionRole() {
    
  }

  public PermissionRole(string roleId, AdminPermission permission) {
    RoleId = roleId;
    Permission = permission;
  }
  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  [Display(ResourceType = typeof(LocalizedResource), Name = Entities.Role.LocKey)]
  public string RoleId { get; set; }

  [Display(ResourceType = typeof(LocalizedResource), Name = "permission")]
  public AdminPermission Permission { get; set; }

  public Role Role { get; set; }
}