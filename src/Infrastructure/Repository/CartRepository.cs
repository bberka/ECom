using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class CartRepository : RepositoryBase<Cart>
{
  public CartRepository(DbContext context) : base(context) {
  }
}