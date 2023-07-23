using ECom.Domain.Entities;

namespace ECom.Domain.Abstract;

public interface ICollectionService
{
  public CustomResult CreateCollection(Guid userId, AddCollectionRequest model);
  public CustomResult<Collection> GetCollection(Guid collectionId);
  public CustomResult<Collection> GetCollection(Guid userId, Guid collectionId);
  public CustomResult UpdateCollection(Guid userId, UpdateCollectionRequest model);
  public CustomResult DeleteCollection(Guid userId, Guid collectionId);
  public List<Collection> GetCollections(Guid userId);

  public CustomResult<List<CollectionProduct>> GetCollectionProducts(Guid userId, Guid collectionId, ushort page,
    string culture = ConstantMgr.DefaultCulture);
}