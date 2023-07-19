using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class CollectionProductRepository : GenericRepository<CollectionProduct, EComDbContext>
{
  public CollectionProductRepository(EComDbContext context) : base(context) {
  }
}