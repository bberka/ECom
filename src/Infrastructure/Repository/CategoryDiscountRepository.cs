using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class CategoryDiscountRepository : GenericRepository<CategoryDiscount, EComDbContext>
{
  public CategoryDiscountRepository(EComDbContext context) : base(context) {
  }
}