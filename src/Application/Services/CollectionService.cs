using ECom.Domain.Results;

namespace ECom.Application.Services
{

    public class CollectionService : ICollectionService
	{
		private readonly IEfEntityRepository<Collection> _collectionRepo;
		private readonly IEfEntityRepository<CollectionProduct> _collectionProductRepo;
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public CollectionService(
			IEfEntityRepository<Collection> collectionRepo,
			IEfEntityRepository<CollectionProduct> collectionProductRepo,
			IUserService userService,
			IProductService productService)
		{
			this._collectionRepo = collectionRepo;
			this._collectionProductRepo = collectionProductRepo;
            this._userService = userService;
            this._productService = productService;
        }

		public Result CreateCollection(AddCollectionRequest model)
		{
			var createResult = _collectionRepo.Add(new Collection
			{
				RegisterDate = DateTime.Now,
				UserId = model.AuthenticatedUserId,
				Name = model.Name,
			});
			if (!createResult)
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
            var collectionProducts = _collectionProductRepo.GetList(x => x.CollectionId == collectionId);
            if (collectionProducts.Any())
            {
                var collectionProductDeleteResult = _collectionProductRepo.DeleteRange(collectionProducts);
                if (collectionProductDeleteResult == 0)
                {
                    return DomainResult.DbInternalErrorResult(2);
                }
            }
			var res = _collectionRepo.Delete(collectionId);
			if (!res)
            {
                return DomainResult.DbInternalErrorResult(3);
            }
            return DomainResult.Collection.CreateSuccessResult();
        }

        public ResultData<Collection> GetCollection(int id)
        {
			var collection = _collectionRepo.Find(id);
			if(collection is null) return DomainResult.Collection.NotFoundResult(1); 
            return collection;
        }

        public ResultData<Collection> GetCollection(int userId, int id)
        {
            var collection = _collectionRepo.Find(id);
            if (collection is null) return DomainResult.Collection.NotFoundResult(1);
            if (collection.UserId == userId) return DomainResult.User.NotAuthorizedResult(2);
            return collection;
        }


        public ResultData<List<CollectionProduct>> GetCollectionProducts(int userId,int id,ushort page, string culture = ConstantMgr.DefaultCulture)
        {
			var collectionResult = GetCollection(userId,id);
			if (collectionResult.IsFailure) return collectionResult.ToResult();
			return _collectionProductRepo
				.Get(x => x.CollectionId == id)
                .Include(x => x.Product)
                .ThenInclude(x => x.ProductDetails)
				.ToList();
        }

        public List<Collection> GetCollections(int userId)
        {
			return _collectionRepo.GetList(x => x.UserId == userId);
        }

        public Result UpdateCollection(UpdateCollectionRequest model)
        {
			var collectionResult = GetCollection(model.AuthenticatedUserId,model.CollectionId);
			if (collectionResult.IsFailure)
            {
                return collectionResult.ToResult();
			}
            collectionResult.Data.Name = model.CollectionName;
			var res = _collectionRepo.Update(collectionResult.Data);	
			if(!res)
            {
                return DomainResult.DbInternalErrorResult(1 * 10);
            }
            return DomainResult.Collection.UpdateSuccessResult();
        }
    }
}
