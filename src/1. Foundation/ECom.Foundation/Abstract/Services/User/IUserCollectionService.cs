using ECom.Foundation.DTOs.Request;
using ECom.Foundation.Entities;
using ECom.Foundation.Enum;

namespace ECom.Foundation.Abstract.Services.User;

public interface IUserCollectionService
{
  public Result CreateCollection(Guid userId, Request_Collection_Add model);

  public Result DeleteCollection(Guid userId, Guid collectionId);

  public Result<List<CollectionProduct>> GetCollectionProducts(
    Guid userId,
    Guid collectionId,
    ushort page,
    Language culture = ConstantContainer.DefaultLanguage);

  Result UpdateCollection(Guid authId, Request_Collection_Update request);
}