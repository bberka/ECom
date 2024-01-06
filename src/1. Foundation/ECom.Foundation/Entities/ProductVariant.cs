using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("ProductVariant", Schema = "ECPrivate")]
public class ProductVariant : IEntity
{
  [Key]
  public Guid Id { get; set; }

  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string Name { get; set; }
}