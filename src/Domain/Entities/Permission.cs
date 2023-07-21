using EasMe.EntityFrameworkCore;

namespace ECom.Domain.Entities;

[Table("Permissions", Schema = "ECEnum")]

public class Permission : IEntity
{
  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  [Key]
  public string Name { get; set; }
  
  public IEnumerable<PermissionRole> PermissionRoles { get; set; } = new List<PermissionRole>();

}