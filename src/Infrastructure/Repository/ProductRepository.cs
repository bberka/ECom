using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class ProductRepository : RepositoryBase<Product>
{
  public ProductRepository(DbContext context) : base(context) {
  }
}