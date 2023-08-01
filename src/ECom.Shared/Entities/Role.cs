using ECom.Shared.Attributes;
using ECom.Shared.Resources;

namespace ECom.Shared.Entities;

[Table("Roles", Schema = "ECOperation")]
public sealed class Role : IEntity
{
  public const string LocKey = "role";
  public const string OwnerRoleId = "owner";
  public Role() {
    
  }
  [Key]
  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  [Display(ResourceType = typeof(LocalizedResource), Name = "role")]
  public string Id { get; set; }

  [EnsureOneElement(Name = "permission")]
  [Display(ResourceType = typeof(LocalizedResource), Name = "permissions")]
  public List<PermissionRole> PermissionRoles { get; set; } = new List<PermissionRole>();


  public IReadOnlyCollection<AdminPermission> GetAdminPermissions() {
    return PermissionRoles
      .Select(x => x.Permission)
      .ToList()
      .AsReadOnly();
  }

}