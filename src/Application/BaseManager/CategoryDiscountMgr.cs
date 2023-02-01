
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.BaseManager
{
	public class CategoryDiscountMgr : EfEntityRepositoryBase<CategoryDiscount, EComDbContext>
	{

		private CategoryDiscountMgr() { }
		public static CategoryDiscountMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static CategoryDiscountMgr? Instance;
	}
	
}
