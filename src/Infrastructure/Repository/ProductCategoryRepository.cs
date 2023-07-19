using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class ProductCategoryRepository : GenericRepository<ProductCategory, EComDbContext>
{
  public ProductCategoryRepository(EComDbContext context) : base(context) {
  }
}   
