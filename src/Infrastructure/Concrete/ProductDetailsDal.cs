using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Infrastructure.Concrete
{
	public class ProductDetailsDal : EfEntityRepositoryBase<ProductDetails, EComDbContext>
	{

		private ProductDetailsDal() { }
		public static ProductDetailsDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static ProductDetailsDal? Instance;
	}
}
