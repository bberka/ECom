namespace ECom.Foundation.Entities;

[Table("ProductVariant", Schema = "ECPrivate")]
public class ProductVariant : IEntity
{
  [Key]
  public Guid Id { get; set; }

  [MaxLength(ConstantContainer.MaxNameLength)]
  public string Name { get; set; }
}