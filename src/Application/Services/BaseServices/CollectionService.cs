using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Constants;
using ECom.Shared.Entities;

namespace ECom.Application.Services.BaseServices;

public abstract class CollectionService : ICollectionService
{
    private readonly IUnitOfWork UnitOfWork;

    protected CollectionService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public CustomResult CreateCollection(Guid userId, CollectionAddRequestDto model)
    {
        var clc = new Collection
        {
            RegisterDate = DateTime.Now,
            UserId = userId,
            Name = model.Name
        };
        UnitOfWork.Collections.Add(clc);
        var res = UnitOfWork.Save();
        if (!res) return DomainResult.DbInternalError(nameof(CreateCollection));
        return DomainResult.OkAdded(nameof(Collection));
    }

    public CustomResult DeleteCollection(Guid userId, Guid collectionId)
    {
        var collectionResult = GetCollection(userId, collectionId);
        if (!collectionResult.Status) return collectionResult;
        var collectionProducts = UnitOfWork.CollectionProducts.Where(x => x.CollectionId == collectionId)
          .Include(x => x.Collection);
        if (collectionProducts.Any()) UnitOfWork.CollectionProducts.RemoveRange(collectionProducts);
        UnitOfWork.Collections.Remove(collectionResult.Data!);
        var res = UnitOfWork.Save();
        if (!res) return DomainResult.DbInternalError(nameof(DeleteCollection));
        return DomainResult.OkDeleted(nameof(Collection));
    }

    public CustomResult<Collection> GetCollection(Guid id)
    {
        var collection = UnitOfWork.Collections.Find(id);
        if (collection is null) return DomainResult.NotFound(nameof(Collection));
        return collection;
    }

    public CustomResult<Collection> GetCollection(Guid userId, Guid id)
    {
        var collection = UnitOfWork.Collections.Find(id);
        if (collection is null) return DomainResult.NotFound(nameof(Collection));
        if (collection.UserId == userId) return DomainResult.Unauthorized();
        return collection;
    }


    public CustomResult<List<CollectionProduct>> GetCollectionProducts(Guid userId, Guid id, ushort page,
      string culture = ConstantMgr.DefaultCulture)
    {
        var collectionResult = GetCollection(userId, id);
        if (!collectionResult.Status) return collectionResult.ToResult();
        return UnitOfWork.CollectionProducts.Where(x => x.CollectionId == id)
          .Include(x => x.Product)
          //.ThenInclude(x => x.ProductDetails)
          .ToList();
    }

    public List<Collection> GetCollections(Guid userId)
    {
        return UnitOfWork.Collections.Where(x => x.UserId == userId).ToList();
    }

    public CustomResult UpdateCollection(Guid userId, UpdateCollectionRequest model)
    {
        var collectionResult = GetCollection(userId, model.CollectionId);
        if (!collectionResult.Status) return collectionResult;
        collectionResult.Data!.Name = model.CollectionName;
        UnitOfWork.Collections.Update(collectionResult.Data);
        var res = UnitOfWork.Save();
        if (!res) return DomainResult.DbInternalError(nameof(UpdateCollection));
        return DomainResult.OkUpdated(nameof(Collection));
    }
}