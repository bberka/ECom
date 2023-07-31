namespace ECom.Shared.Entities;

[Table("Permissions", Schema = "ECEnum")]

public class Permission : IEntity
{
  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  [Key]
  public string Id { get; set; }
  
  public IEnumerable<Role> Roles { get; set; } = new List<Role>();

}