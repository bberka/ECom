using ECom.Shared.Entities;

namespace ECom.Shared.Abstract.Services.User;

public interface IUserCollectionService
{
  public CustomResult CreateCollection(Guid userId, AddCollectionRequest model);
  public CustomResult<List<CollectionProduct>> GetCollectionProducts(
    Guid userId,
    Guid collectionId,
    ushort page,
    string culture = ConstantMgr.DefaultCulture);
}