using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("Roles", Schema = "ECOperation")]
public sealed class Role : IEntity
{
  public const string OWNER_ROLE_ID = "owner";

  [Key]
  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
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