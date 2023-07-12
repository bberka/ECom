namespace ECom.Infrastructure.Repository;

public class OrderRepository : GenericRepository<Order, EComDbContext>
{
  public OrderRepository(EComDbContext context) : base(context) {
  }
}