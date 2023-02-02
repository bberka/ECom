
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Services
{
	public class CategoryDiscountService : EfEntityRepositoryBase<CategoryDiscount, EComDbContext>
	{

		private CategoryDiscountService() { }
		public static CategoryDiscountService This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static CategoryDiscountService? Instance;
	}
	
}
