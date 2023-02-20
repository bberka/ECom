using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class ProductRepository : GenericRepository<Product,EComDbContext>
{
    public ProductRepository(EComDbContext context) : base(context)
    {
    }
}