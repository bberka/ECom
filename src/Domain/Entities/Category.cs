namespace ECom.Domain.Entities;

[Table("Categories", Schema = "ECPrivate")]
[PrimaryKey(nameof(NameKey))]
[Index(nameof(NameKey), nameof(ParentNameKey))]
public class Category : IEntity
{
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }
  public int Order { get; set; }

  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  public string NameKey { get; set; }

  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  public string? ParentNameKey { get; set; }
}