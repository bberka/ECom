namespace ECom.Infrastructure.Repository;

public class DiscountNotifyRepository : GenericRepository<DiscountNotify, EComDbContext>
{
  public DiscountNotifyRepository(EComDbContext context) : base(context) {
  }
}