using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class StockChangeRepository : RepositoryBase<StockChange>
{
  public StockChangeRepository(DbContext context) : base(context) {
  }
}