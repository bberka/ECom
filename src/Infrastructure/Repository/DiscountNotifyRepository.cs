using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class DiscountNotifyRepository : GenericRepository<DiscountNotify, EComDbContext>
{
    public DiscountNotifyRepository(EComDbContext context) : base(context)
    {
    }
}