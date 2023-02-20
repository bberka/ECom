using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class CategoryDiscountRepository : GenericRepository<CategoryDiscount,EComDbContext>
{
    public CategoryDiscountRepository(EComDbContext context) : base(context)
    {
    }
}