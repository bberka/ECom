using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class CategoryRepository : RepositoryBase<Category>
{
  public CategoryRepository(DbContext context) : base(context) {
  }
}