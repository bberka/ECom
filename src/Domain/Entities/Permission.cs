namespace ECom.Domain.Entities;

[Table("Permissions", Schema = "ECOperation")]
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

  public static PermissionDto ToDto(Permission permission) {
    return new PermissionDto {
      Id = permission.Id,
      Name = permission.Name,
      Memo = permission.Memo,
      IsValid = permission.IsValid
    };
  }
}