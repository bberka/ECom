using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.Services
{
	public interface ICollectionService 
	{
	}
	public class CollectionService : ICollectionService
	{
		private readonly IEfEntityRepository<Collection> _collectionRepo;
		private readonly IEfEntityRepository<CollectionProduct> _collectionProductRepo;

		public CollectionService(
			IEfEntityRepository<Collection> collectionRepo,
			IEfEntityRepository<CollectionProduct> collectionProductRepo)
		{
			this._collectionRepo = collectionRepo;
			this._collectionProductRepo = collectionProductRepo;
		}
	}
}
