using ECom.Domain.DTOs.CollectionDTOs;

namespace ECom.Application.Services;

public class CollectionService : ICollectionService
{
  private readonly IUnitOfWork _unitOfWork;

  public CollectionService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public Result CreateCollection(AddCollectionRequest model) {
    var collection = new Collection {
      RegisterDate = DateTime.Now,
      UserId = model.AuthenticatedUserId,
      Name = model.Name
    };
    _unitOfWork.CollectionRepository.Insert(collection);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Collection.CreateSuccessResult();
  }

  public Result DeleteCollection(int userId, int collectionId) {
    var collectionResult = GetCollection(userId, collectionId);
    if (collectionResult.IsFailure) return collectionResult.ToResult();
    var collectionProducts = _unitOfWork.CollectionProductRepository.Get(x => x.CollectionId == collectionId);
    if (collectionProducts.Any()) _unitOfWork.CollectionProductRepository.DeleteRange(collectionProducts);
    _unitOfWork.CollectionRepository.Delete(collectionId);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Collection.CreateSuccessResult();
  }

  public ResultData<Collection> GetCollection(int id) {
    var collection = _unitOfWork.CollectionRepository.GetById(id);
    if (collection is null) return DomainResult.Collection.NotFoundResult();
    return collection;
  }

  public ResultData<Collection> GetCollection(int userId, int id) {
    var collection = _unitOfWork.CollectionRepository.GetById(id);
    if (collection is null) return DomainResult.Collection.NotFoundResult();
    if (collection.UserId == userId) return DomainResult.User.NotAuthorizedResult();
    return collection;
  }


  public ResultData<List<CollectionProduct>> GetCollectionProducts(int userId, int id, ushort page,
    string culture = ConstantMgr.DefaultCulture) {
    var collectionResult = GetCollection(userId, id);
    if (collectionResult.IsFailure) return collectionResult.ToResult();
    return _unitOfWork.CollectionProductRepository
      .Get(x => x.CollectionId == id)
      .Include(x => x.Product)
      //.ThenInclude(x => x.ProductDetails)
      .ToList();
  }

  public List<Collection> GetCollections(int userId) {
    return _unitOfWork.CollectionRepository.Get(x => x.UserId == userId).ToList();
  }

  public Result UpdateCollection(UpdateCollectionRequest model) {
    var collectionResult = GetCollection(model.AuthenticatedUserId, model.CollectionId);
    if (collectionResult.IsFailure) return collectionResult.ToResult();
    collectionResult.Data.Name = model.CollectionName;
    _unitOfWork.CollectionRepository.Update(collectionResult.Data);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Collection.UpdateSuccessResult();
  }
}