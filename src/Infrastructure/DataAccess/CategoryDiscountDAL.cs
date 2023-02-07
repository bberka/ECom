using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.DataAccess
{
	public class CategoryDiscountDal : EfEntityRepositoryBase<CategoryDiscount, EComDbContext>, IEfEntityRepository<CategoryDiscount>
	{
	}
}
