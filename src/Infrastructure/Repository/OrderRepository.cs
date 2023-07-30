using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class OrderRepository : RepositoryBase<Order>
{
  public OrderRepository(DbContext context) : base(context) {
  }
}