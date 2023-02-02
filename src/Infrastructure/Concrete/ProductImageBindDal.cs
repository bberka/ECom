using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Infrastructure.Concrete
{
	public class ProductImageBindDal : EfEntityRepositoryBase<ProductImageBind, EComDbContext>
	{

		private ProductImageBindDal() { }
		public static ProductImageBindDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static ProductImageBindDal? Instance;
	}
}
