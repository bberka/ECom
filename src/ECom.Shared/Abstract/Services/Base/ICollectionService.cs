using ECom.Shared.Entities;

namespace ECom.Shared.Abstract.Services.Base;

public interface ICollectionService
{
  public List<Collection> GetCollections(Guid userId);
  
  public CustomResult<Collection> GetCollection(Guid userId, Guid collectionId);
  

}