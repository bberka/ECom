using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class CollectionRepository : RepositoryBase<Collection>
{
  public CollectionRepository(DbContext context) : base(context) {
  }
}