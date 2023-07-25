using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class DiscountNotifyRepository : RepositoryBase<DiscountNotify>
{
  public DiscountNotifyRepository(DbContext context) : base(context) {
  }
}