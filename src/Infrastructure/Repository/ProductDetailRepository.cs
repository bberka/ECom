using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class ProductDetailRepository : RepositoryBase<ProductDetail>
{
  public ProductDetailRepository(DbContext context) : base(context) {
  }
}