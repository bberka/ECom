namespace ECom.Foundation.Entities;

[PrimaryKey(nameof(ProductId), nameof(CategoryId))]
[Table("ProductCategories", Schema = "ECPrivate")]
public class ProductCategory : IEntity
{
  [ForeignKey("product")]
  public Guid ProductId { get; set; }

  [ForeignKey("category")]
  public Guid CategoryId { get; set; }
}