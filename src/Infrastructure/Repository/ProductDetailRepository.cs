namespace ECom.Infrastructure.Repository;

public class ProductDetailRepository : GenericRepository<ProductDetail, EComDbContext>
{
  public ProductDetailRepository(EComDbContext context) : base(context) {
  }
}