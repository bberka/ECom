using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class DiscountCouponRepository : RepositoryBase<DiscountCoupon>
{
  public DiscountCouponRepository(DbContext context) : base(context) {
  }
}