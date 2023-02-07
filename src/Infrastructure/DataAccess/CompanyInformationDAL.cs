using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.DataAccess
{
	public class CompanyInformationDal : EfEntityRepositoryBase<CompanyInformation, EComDbContext>, IEfEntityRepository<CompanyInformation>
	{
	}
}
