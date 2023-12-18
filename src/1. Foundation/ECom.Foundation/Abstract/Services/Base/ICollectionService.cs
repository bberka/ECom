using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Base;

public interface ICollectionService
{
  public List<Collection> GetCollections(Guid userId);

  public Result<Collection> GetCollection(Guid userId, Guid collectionId);
}