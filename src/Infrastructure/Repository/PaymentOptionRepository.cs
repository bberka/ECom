using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class PaymentOptionRepository : GenericRepository<PaymentOption,EComDbContext>
{
    public PaymentOptionRepository(EComDbContext context) : base(context)
    {
    }
}