using ECom.Foundation.Static;

namespace ECom.Business.Services.BaseServices;

public class CollectionService : ICollectionService
{
  private readonly IUnitOfWork _unitOfWork;

  public CollectionService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public Result<Collection> GetCollection(Guid userId, Guid id) {
    var collection = _unitOfWork.Collections.Find(id);
    if (collection is null) return DomResults.x_is_not_found("Collection");
    if (collection.UserId == userId) return DomResults.unauthorized();
    return collection;
  }

  public List<Collection> GetCollections(Guid userId) {
    return _unitOfWork.Collections.Where(x => x.UserId == userId).ToList();
  }

  public Result CreateCollection(Guid userId, Request_Collection_Add model) {
    var clc = new Collection {
      RegisterDate = DateTime.Now,
      UserId = userId,
      Name = model.Name
    };
    _unitOfWork.Collections.Add(clc);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(CreateCollection));
    return DomResults.x_is_added_successfully("collection");
  }

  public Result DeleteCollection(Guid userId, Guid collectionId) {
    var collectionResult = GetCollection(userId, collectionId);
    if (!collectionResult.Status) return collectionResult.ToResult();
    var collectionProducts = _unitOfWork.CollectionProducts.Where(x => x.CollectionId == collectionId)
                                        .Include(x => x.Collection);
    if (collectionProducts.Any()) _unitOfWork.CollectionProducts.RemoveRange(collectionProducts);
    _unitOfWork.Collections.Remove(collectionResult.Value!);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(DeleteCollection));
    return DomResults.x_is_deleted_successfully("collection");
  }

  public Result<Collection> GetCollection(Guid id) {
    var collection = _unitOfWork.Collections.Find(id);
    if (collection is null) return DomResults.x_is_not_found("collection");
    return collection;
  }


  public Result<List<CollectionProduct>> GetCollectionProducts(Guid userId,
                                                               Guid id,
                                                               ushort page,
                                                               CultureType culture = StaticValues.DEFAULT_LANGUAGE) {
    var collectionResult = GetCollection(userId, id);
    if (!collectionResult.Status) return collectionResult.ToResult();
    return _unitOfWork.CollectionProducts.Where(x => x.CollectionId == id)
                      .Include(x => x.Product)
                      //.ThenInclude(x => x.ProductDetails)
                      .ToList();
  }

  public Result UpdateCollection(Guid userId, Request_Collection_Update model) {
    var collectionResult = GetCollection(userId, model.CollectionId);
    if (!collectionResult.Status) return collectionResult.ToResult();
    collectionResult.Value!.Name = model.CollectionName;
    _unitOfWork.Collections.Update(collectionResult.Value);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(UpdateCollection));
    return DomResults.x_is_updated_successfully("collection");
  }
}