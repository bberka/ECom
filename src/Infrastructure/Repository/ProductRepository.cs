using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class ProductRepository : GenericRepository<Product, EComDbContext>
{
  public ProductRepository(EComDbContext context) : base(context) {
  }
}