namespace ECom.Infrastructure.Repository;

public class ProductVariantRepository : GenericRepository<ProductVariant, EComDbContext>
{
  public ProductVariantRepository(EComDbContext context) : base(context) {
  }
}   
