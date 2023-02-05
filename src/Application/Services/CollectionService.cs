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
			if (!createResult) throw new DbInternalException(nameof(CreateCollection));
			return Result.Success("Added:Collection");
		}

        public Result DeleteCollection(int id)
        {
			var data = _collectionRepo.Find(id);
			if (data is null) throw new NotFoundException(nameof(Collection));
			var res = _collectionRepo.Delete(id);
			if (!res) throw new DbInternalException(nameof(DeleteCollection));
			return Result.Success("Deleted");
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

        public List<ListCollectionProductsResponseModel> GetCollectionProducts(int userId,int id)
        {
			_userService.CheckExistsOrThrow(userId);
			var collection = GetCollectionOrThrow(id);
			var collectionProducts = _collectionProductRepo.GetList(x => x.CollectionId == id);
			//var result = new ListCollectionProductsResponseModel
			//{
			//	Collection = collection,
			//	Products = products,
			//};
			throw new NotImplementedException();
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
			if (collection is null) throw new NotFoundException(nameof(Collection));
			collection.Name = model.CollectionName;
			var res = _collectionRepo.Update(collection);	
			if(!res) throw new DbInternalException(nameof(UpdateCollection));
			return Result.Success("Updated");
        }
    }
}
