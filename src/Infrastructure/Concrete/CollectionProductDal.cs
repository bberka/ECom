using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Infrastructure.Concrete
{
	public class CollectionProductDal : EfEntityRepositoryBase<CollectionProduct, EComDbContext>
	{

		private CollectionProductDal() { }
		public static CollectionProductDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static CollectionProductDal? Instance;
	}
}
