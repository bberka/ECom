namespace ECom.Domain.Entities;

[PrimaryKey(nameof(ProductId), nameof(SubCategoryId))]
[Table("ProductSubCategories", Schema = "ECPrivate")]
public class ProductSubCategory : IEntity
{
  [ForeignKey(nameof(Product))]
  public int ProductId { get; set; }

  [ForeignKey(nameof(SubCategory))]
  public int SubCategoryId { get; set; }
}