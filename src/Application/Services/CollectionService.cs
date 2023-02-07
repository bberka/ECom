using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		public Result CreateCollection(CreateCollectionRequestModel model)
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

        public Result DeleteCollection(int id)
        {
			var data = _collectionRepo.Find(id);
			if (data is null)
            {
                return DomainResult.Collection.NotFoundResult(1);
            }

            var collectionProducts = _collectionProductRepo.GetList(x => x.CollectionId == id);
            if (collectionProducts.Any())
            {
                var collectionProductDeleteResult = _collectionProductRepo.DeleteRange(collectionProducts);
                if (collectionProductDeleteResult == 0)
                {
                    return DomainResult.DbInternalErrorResult(2);
                }
            }
			var res = _collectionRepo.Delete(id);
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


        public ListCollectionProductsResponseModel GetCollectionProducts(int userId,int id)
        {
			_userService.Exists(userId);
			var collection = GetCollection(id);
			if (collection.IsFailure) return new ListCollectionProductsResponseModel();
			var collectionProductIds = _collectionProductRepo
				.Get(x => x.CollectionId == id)
				.Select(x => x.ProductId)
				.ToList();
			var productDTOs = _productService.GetProductDTOs(collectionProductIds);
			var result = new ListCollectionProductsResponseModel
			{
				Collection = collection.Data,
				Products = productDTOs,
			};
			return result;
        }

        public List<Collection> GetCollections(int userId)
        {
			_userService.CheckExistsOrThrow(userId);	
			return _collectionRepo.GetList(x => x.UserId == userId);
        }

        public Result UpdateCollection(UpdateCollectionRequestModel model)
        {
			_userService.CheckExistsOrThrow(model.AuthenticatedUserId);
			var collectionResult = GetCollection(model.CollectionId);
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
