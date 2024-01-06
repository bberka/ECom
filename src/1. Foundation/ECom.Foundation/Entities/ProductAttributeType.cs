using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("ProductAttributeTypes", Schema = "ECEnum")]
public class ProductAttributeType : IEntity
{
  [Key]
  public Guid Id { get; set; }

  [MaxLength(StaticValues.MAX_ATTRIBUTE_NAME_LENGTH)]
  public string Name { get; set; }
}