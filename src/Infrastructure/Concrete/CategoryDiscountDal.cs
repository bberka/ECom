
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Concrete
{
	public class CategoryDiscountDal : EfEntityRepositoryBase<CategoryDiscount, EComDbContext>
	{

		private CategoryDiscountDal() { }
		public static CategoryDiscountDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static CategoryDiscountDal? Instance;
	}
	
}
