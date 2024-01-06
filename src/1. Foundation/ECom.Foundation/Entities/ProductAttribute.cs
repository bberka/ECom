using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("ProductDetailAttributes", Schema = "ECPrivate")]
[Index(nameof(ProductAttributeTypeId), nameof(ProductId), nameof(Value), IsUnique = true)]
public class ProductAttribute
{
  [Key]
  public Guid Id { get; set; }

  public Guid ProductAttributeTypeId { get; set; }
  public virtual ProductAttributeType ProductAttributeType { get; set; }
  public Guid ProductId { get; set; }
  public virtual Product Product { get; set; }

  [MaxLength(StaticValues.MAX_ATTRIBUTE_VALUE_LENGTH)]
  public string Value { get; set; } //Red, XL, 100KG, 256GB etc. 
}