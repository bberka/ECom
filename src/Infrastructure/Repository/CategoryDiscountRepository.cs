using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class CategoryDiscountRepository : RepositoryBase<CategoryDiscount>
{
  public CategoryDiscountRepository(DbContext context) : base(context) {
  }
}