using ECom.Domain.Entities;
using ECom.Shared.Constants;

namespace ECom.Application.Services;

public class CollectionService : ICollectionService
{
  private readonly IUnitOfWork _unitOfWork;

  public CollectionService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public CustomResult CreateCollection(Guid userId, AddCollectionRequest model) {
    var clc = new Collection {
      RegisterDate = DateTime.Now,
      UserId = userId,
      Name = model.Name
    };
    _unitOfWork.CollectionRepository.Insert(clc);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(CreateCollection));
    return DomainResult.OkAdded(nameof(Collection));
  }

  public CustomResult DeleteCollection(Guid userId, Guid collectionId) {
    var collectionResult = GetCollection(userId, collectionId);
    if (!collectionResult.Status) return collectionResult;
    var collectionProducts = _unitOfWork.CollectionProductRepository.Get(x => x.CollectionId == collectionId)
      .Include(x => x.Collection);
    if (collectionProducts.Any()) _unitOfWork.CollectionProductRepository.DeleteRange(collectionProducts);
    _unitOfWork.CollectionRepository.Delete(collectionResult.Data!);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteCollection));
    return DomainResult.OkDeleted(nameof(Collection));
  }

  public CustomResult<Collection> GetCollection(Guid id) {
    var collection = _unitOfWork.CollectionRepository.Find(id);
    if (collection is null) return DomainResult.NotFound(nameof(Collection));
    return collection;
  }

  public CustomResult<Collection> GetCollection(Guid userId, Guid id) {
    var collection = _unitOfWork.CollectionRepository.Find(id);
    if (collection is null) return DomainResult.NotFound(nameof(Collection));
    if (collection.UserId == userId) return DomainResult.Unauthorized();
    return collection;
  }


  public CustomResult<List<CollectionProduct>> GetCollectionProducts(Guid userId, Guid id, ushort page,
    string culture = ConstantMgr.DefaultCulture) {
    var collectionResult = GetCollection(userId, id);
    if (!collectionResult.Status) return collectionResult.ToResult();
    return _unitOfWork.CollectionProductRepository.Get(x => x.CollectionId == id)
      .Include(x => x.Product)
      //.ThenInclude(x => x.ProductDetails)
      .ToList();
  }

  public List<Collection> GetCollections(Guid userId) {
    return _unitOfWork.CollectionRepository.Get(x => x.UserId == userId).ToList();
  }

  public CustomResult UpdateCollection(Guid userId, UpdateCollectionRequest model) {
    var collectionResult = GetCollection(userId, model.CollectionId);
    if (!collectionResult.Status) return collectionResult;
    collectionResult.Data!.Name = model.CollectionName;
    _unitOfWork.CollectionRepository.Update(collectionResult.Data);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateCollection));
    return DomainResult.OkUpdated(nameof(Collection));
  }
}