
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Services
{
	public interface ICategoryDiscountService : IEfEntityRepository<CategoryDiscount>
	{
	}
	public class CategoryDiscountService : EfEntityRepositoryBase<CategoryDiscount, EComDbContext>, ICategoryDiscountService
	{

	
	}
	
}
