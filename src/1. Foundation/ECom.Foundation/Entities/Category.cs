using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("Categories", Schema = "ECPrivate")]
[PrimaryKey(nameof(NameKey))]
[Index(nameof(NameKey), nameof(MainCategoryNameKey))]
public class Category : IEntity
{
  public Category() {
    if (string.IsNullOrEmpty(Link) && !string.IsNullOrEmpty(NameKey)) Link = NameKey.Replace("_", "-");

    RegisterDate = DateTime.Now;
  }

  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;

  public int Order { get; set; }

  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string Link { get; set; }

  public Guid? ImageId { get; set; }

  public bool ShowAtTopMenu { get; set; } = false;

  public bool ShowAtFooter { get; set; } = false;

  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string NameKey { get; set; }

  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string? MainCategoryNameKey { get; set; }

  public virtual Image? Image { get; set; }
}