using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class SubCategoryRepository : GenericRepository<SubCategory, EComDbContext>
{
  public SubCategoryRepository(EComDbContext context) : base(context) {
  }
}