using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECom.Infrastructure.DataAccess;
using ECom.Infrastructure.Abstract;

namespace ECom.Domain.Entities
{
	public class EfAdmin : EfEntityRepositoryBase<Admin, EComDbContext>, IEfAdmin
	{
		
		public bool IsInRole(int adminId, int roleId)
		{
			throw new NotImplementedException();
		}
	}
}
