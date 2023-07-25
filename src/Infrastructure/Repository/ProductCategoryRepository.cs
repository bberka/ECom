using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class ProductCategoryRepository : RepositoryBase<ProductCategory>
{
  public ProductCategoryRepository(DbContext context) : base(context) {
  }
}   
