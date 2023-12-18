using ECom.Foundation.Enum;

namespace ECom.Foundation.Entities;

[Table("Roles", Schema = "ECOperation")]
public sealed class Role : IEntity
{
  public const string LocKey = "role";
  public const string OwnerRoleId = "owner";

  [Key]
  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string Id { get; set; }

  // [EnsureOneElement(Name = "permissionType")]
  public List<PermissionRole> PermissionRoles { get; set; } = new();


  public IReadOnlyCollection<AdminPermissionType> GetAdminPermissions() {
    return PermissionRoles
           .Select(x => x.PermissionType)
           .ToList()
           .AsReadOnly();
  }
}