namespace ECom.Shared.Entities;

[Table("ProductVariants", Schema = "ECPrivate")]
public class ProductVariant : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  [MaxLength(ValidationSettings.MaxDescriptionLength)]
  public string Description { get; set; }
}