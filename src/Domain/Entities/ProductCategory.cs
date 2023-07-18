namespace ECom.Domain.Entities;

[PrimaryKey(nameof(ProductId), nameof(SubCategoryId))]
[Table("ProductCategories", Schema = "ECPrivate")]
public class ProductCategory : IEntity
{
  [ForeignKey(nameof(Product))]
  public int ProductId { get; set; }

  [ForeignKey(nameof(SubCategory))]
  public int SubCategoryId { get; set; }
}