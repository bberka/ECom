using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Infrastructure.Concrete
{
	public class FavoriteProductDal : EfEntityRepositoryBase<FavoriteProduct, EComDbContext>
	{

		private FavoriteProductDal() { }
		public static FavoriteProductDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static FavoriteProductDal? Instance;
	}
}
