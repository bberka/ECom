using ECom.Foundation.DTOs.Request;
using ECom.Foundation.Entities;
using ECom.Foundation.Enum;

namespace ECom.Foundation.Abstract.Services.Admin;

public interface IAdminCollectionService
{
  public Result<Collection> GetCollection(Guid collectionId);
  public Result UpdateCollection(Guid userId, Request_Collection_Update model);
  public Result DeleteCollection(Guid userId, Guid collectionId);

  public Result<List<CollectionProduct>> GetCollectionProducts(
    Guid collectionId,
    ushort page,
    LanguageType language = ConstantContainer.DefaultLanguage);
}