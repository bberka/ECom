using ECom.Domain.Entities;

namespace ECom.Domain.Abstract.Services.Base;

public interface ICollectionService
{
  public List<Collection> GetCollections(Guid userId);
  
  public CustomResult<Collection> GetCollection(Guid userId, Guid collectionId);
  

}