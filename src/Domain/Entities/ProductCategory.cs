using EasMe.EntityFrameworkCore;

namespace ECom.Domain.Entities;

[PrimaryKey(nameof(ProductId), nameof(CategoryId))]
[Table("ProductCategories", Schema = "ECPrivate")]
public class ProductCategory : IEntity
{
  [ForeignKey(nameof(Product))]
  public Guid ProductId { get; set; }

  [ForeignKey(nameof(Category))]
  public Guid CategoryId { get; set; }
}