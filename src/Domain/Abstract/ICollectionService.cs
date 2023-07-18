using ECom.Domain.DTOs.CollectionDto;

namespace ECom.Domain.Abstract;

public interface ICollectionService
{
  public CustomResult CreateCollection(AddCollectionRequest model);
  public CustomResult<Collection> GetCollection(int collectionId);
  public CustomResult<Collection> GetCollection(int userId, int collectionId);
  public CustomResult UpdateCollection(UpdateCollectionRequest model);
  public CustomResult DeleteCollection(int userId, int collectionId);
  public List<Collection> GetCollections(int userId);

  public CustomResult<List<CollectionProduct>> GetCollectionProducts(int userId, int collectionId, ushort page,
    string culture = ConstantMgr.DefaultCulture);
}