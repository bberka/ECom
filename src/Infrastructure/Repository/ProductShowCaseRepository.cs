using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class ProductShowCaseRepository : GenericRepository<ProductShowCase,EComDbContext>
{
    public ProductShowCaseRepository(EComDbContext context) : base(context)
    {
    }
}