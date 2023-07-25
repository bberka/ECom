namespace ECom.Domain.Entities;

[Table("Permissions", Schema = "ECEnum")]

public class Permission : IEntity
{
  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  [Key]
  public string Id { get; set; }
  
  public IEnumerable<PermissionRole> PermissionRoles { get; set; } = new List<PermissionRole>();

}