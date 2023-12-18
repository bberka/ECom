namespace ECom.Foundation.Entities;

[Table("ProductAttributeTypes", Schema = "ECEnum")]
public class ProductAttributeType : IEntity
{
  [Key]
  public Guid Id { get; set; }

  [MaxLength(ConstantContainer.MaxAttributeNameLength)]
  public string Name { get; set; }
}