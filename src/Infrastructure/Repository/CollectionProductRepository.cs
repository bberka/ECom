using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class CollectionProductRepository : RepositoryBase<CollectionProduct>
{
  public CollectionProductRepository(DbContext context) : base(context) {
  }
}