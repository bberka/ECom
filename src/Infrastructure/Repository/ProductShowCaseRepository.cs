using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class ProductShowCaseRepository : GenericRepository<ProductShowCase, EComDbContext>
{
  public ProductShowCaseRepository(EComDbContext context) : base(context) {
  }
}