using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				return Result.DbInternal(1);
			}
			return Result.Success();
		}

        public Result DeleteCollection(int id)
        {
			var data = _collectionRepo.Find(id);
			if (data is null) 
			{
                return Result.Warn(1, ErrorCode.NotFound, nameof(Collection));
            }
			var res = _collectionRepo.Delete(id);
			if (!res) 
			{
                return Result.DbInternal(2);
            }
            return Result.Success();
        }

        public Collection? GetCollection(int id)
        {
			return _collectionRepo.Find(id);
        }
        public Collection GetCollectionOrThrow(int id)
        {
            var res = _collectionRepo.Find(id);
			if(res is null ) throw new NotFoundException(nameof(Collection)); 
			return res;
        }

        public ListCollectionProductsResponseModel GetCollectionProducts(int userId,int id)
        {
			_userService.Exists(userId);
			var collection = GetCollection(id);
			if (collection is null) return new();
			var collectionProductIds = _collectionProductRepo
				.Get(x => x.CollectionId == id)
				.Select(x => x.ProductId)
				.ToList();
			var productDTOs = _productService.GetProductDTOs(collectionProductIds);
			var result = new ListCollectionProductsResponseModel
			{
				Collection = collection,
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
			var collection = GetCollection(model.CollectionId);
			if (collection is null)
			{
				return Result.Warn(1, ErrorCode.NotFound, nameof(Collection));
			}
			collection.Name = model.CollectionName;
			var res = _collectionRepo.Update(collection);	
			if(!res) 
			{
                return Result.Warn(2, ErrorCode.NotFound, nameof(UpdateCollection));
            }
			return Result.Success();
        }
    }
}
