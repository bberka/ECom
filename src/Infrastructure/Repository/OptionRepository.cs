namespace ECom.Infrastructure.Repository;

public class OptionRepository : GenericRepository<Option, EComDbContext>
{
  public OptionRepository(EComDbContext context) : base(context) {
  }
}