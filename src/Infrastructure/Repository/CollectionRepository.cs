namespace ECom.Infrastructure.Repository;

public class CollectionRepository : GenericRepository<Collection, EComDbContext>
{
  public CollectionRepository(EComDbContext context) : base(context) {
  }
}