
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Services
{
	public interface ISecurityLogService : IEfEntityRepository<SecurityLog>
	{
	}
	public class SecurityLogService : EfEntityRepositoryBase<SecurityLog, EComDbContext>, ISecurityLogService
	{

	}
}
