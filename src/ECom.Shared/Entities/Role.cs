namespace ECom.Shared.Entities;

[Table("Roles", Schema = "ECOperation")]
public class Role : IEntity
{
  [Key]
  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  public string Id { get; set; }

  public virtual List<Permission> Permissions { get; set; } = new List<Permission>();

  [NotMapped]
  public int AdminCount { get; set; }
}