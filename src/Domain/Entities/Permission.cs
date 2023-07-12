namespace ECom.Domain.Entities;

[Table("Permissions",Schema = "ECOperation")]
public class Permission : IEntity
{
  [Key]
  public int Id { get; set; }

  [MaxLength(32)]
  public string Name { get; set; }

  [MaxLength(32)]
  public string? Memo { get; set; }

  public bool IsValid { get; set; }

  public IEnumerable<PermissionRole> PermissionRoles { get; set; } = new List<PermissionRole>();
}