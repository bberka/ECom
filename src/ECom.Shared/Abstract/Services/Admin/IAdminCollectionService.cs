using ECom.Shared.Entities;

namespace ECom.Shared.Abstract.Services.Admin;

public interface IAdminCollectionService
{
  public CustomResult<Collection> GetCollection(Guid collectionId);
  public CustomResult UpdateCollection(Guid userId, UpdateCollectionRequest model);
  public CustomResult DeleteCollection(Guid userId, Guid collectionId);
  public CustomResult<List<CollectionProduct>> GetCollectionProducts(
    Guid collectionId,
    ushort page,
    string culture = ConstantMgr.DefaultCulture);
}