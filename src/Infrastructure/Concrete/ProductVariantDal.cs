using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Infrastructure.Concrete
{
	public class ProductVariantDal : EfEntityRepositoryBase<ProductVariant, EComDbContext>
	{

		private ProductVariantDal() { }
		public static ProductVariantDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static ProductVariantDal? Instance;
	}
}
