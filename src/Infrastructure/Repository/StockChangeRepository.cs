namespace ECom.Infrastructure.Repository;

public class StockChangeRepository : GenericRepository<StockChange, EComDbContext>
{
  public StockChangeRepository(EComDbContext context) : base(context) {
  }
}