using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class CategoryRepository : GenericRepository<Category,EComDbContext>
{
    public CategoryRepository(EComDbContext context) : base(context)
    {
    }
}