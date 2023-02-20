using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class CartRepository : GenericRepository<Cart,EComDbContext>
{
    public CartRepository(EComDbContext context) : base(context)
    {
    }
}