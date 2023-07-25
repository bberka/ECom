using ECom.Domain.Entities;

namespace ECom.Domain.Abstract.Services.User;

public interface IUserCollectionService
{
  public CustomResult CreateCollection(Guid userId, AddCollectionRequest model);
  public CustomResult<List<CollectionProduct>> GetCollectionProducts(
    Guid userId,
    Guid collectionId,
    ushort page,
    string culture = ConstantMgr.DefaultCulture);
}