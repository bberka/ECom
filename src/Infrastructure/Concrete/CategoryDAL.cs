using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Concrete
{
	public class CategoryDAL : EfEntityRepositoryBase<Category, EComDbContext>, IEfEntityRepository<Category>
	{
	}
}
