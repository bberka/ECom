using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class DiscountCouponRepository : GenericRepository<DiscountCoupon, EComDbContext>
{
  public DiscountCouponRepository(EComDbContext context) : base(context) {
  }
}