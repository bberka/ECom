using ECom.Domain.DTOs.CollectionDTOs;
using ECom.Domain.Results;

namespace ECom.Application.Services
{

    public class CollectionService : ICollectionService
	{
        private readonly IUnitOfWork _unitOfWork;

        public CollectionService(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;
        }

		public Result CreateCollection(AddCollectionRequest model)
		{
			_unitOfWork.CollectionRepository.Add(new Collection
			{
				RegisterDate = DateTime.Now,
				UserId = model.AuthenticatedUserId,
				Name = model.Name,
			});
            var res = _unitOfWork.Save();
			if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
			}
            return DomainResult.Collection.CreateSuccessResult();
		}

        public Result DeleteCollection(int userId, int collectionId)
        {
            var collectionResult = GetCollection(userId, collectionId);
            if (collectionResult.IsFailure)
            {
                return collectionResult.ToResult(10);
            }
            var collectionProducts = _unitOfWork.CollectionProductRepository.GetList(x => x.CollectionId == collectionId);
            if (collectionProducts.Any())
            {
                _unitOfWork.CollectionProductRepository.DeleteRange(collectionProducts);
            }
			_unitOfWork.CollectionRepository.Delete(collectionId);
            var res = _unitOfWork.Save();
			if (!res)
            {
                return DomainResult.DbInternalErrorResult(3);
            }
            return DomainResult.Collection.CreateSuccessResult();
        }

        public ResultData<Collection> GetCollection(int id)
        {
			var collection = _unitOfWork.CollectionRepository.Find(id);
			if(collection is null) return DomainResult.Collection.NotFoundResult(1); 
            return collection;
        }

        public ResultData<Collection> GetCollection(int userId, int id)
        {
            var collection = _unitOfWork.CollectionRepository.Find(id);
            if (collection is null) return DomainResult.Collection.NotFoundResult(1);
            if (collection.UserId == userId) return DomainResult.User.NotAuthorizedResult(2);
            return collection;
        }


        public ResultData<List<CollectionProduct>> GetCollectionProducts(int userId,int id,ushort page, string culture = ConstantMgr.DefaultCulture)
        {
			var collectionResult = GetCollection(userId,id);
			if (collectionResult.IsFailure) return collectionResult.ToResult();
			return _unitOfWork.CollectionProductRepository
				.Get(x => x.CollectionId == id)
                .Include(x => x.Product)
                .ThenInclude(x => x.ProductDetails)
				.ToList();
        }

        public List<Collection> GetCollections(int userId)
        {
			return _unitOfWork.CollectionRepository.GetList(x => x.UserId == userId);
        }

        public Result UpdateCollection(UpdateCollectionRequest model)
        {
			var collectionResult = GetCollection(model.AuthenticatedUserId,model.CollectionId);
			if (collectionResult.IsFailure)
            {
                return collectionResult.ToResult(100);
			}
            collectionResult.Data.Name = model.CollectionName;
			_unitOfWork.CollectionRepository.Update(collectionResult.Data);
            var res = _unitOfWork.Save();
			if(!res)
            {
                return DomainResult.DbInternalErrorResult(1);
            }
            return DomainResult.Collection.UpdateSuccessResult();
        }
    }
}
