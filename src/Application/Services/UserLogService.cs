
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Services
{
	public interface IUserLogService : IEfEntityRepository<UserLog>
	{
	}
	public class UserLogService : EfEntityRepositoryBase<UserLog, EComDbContext>, IUserLogService
	{

	}
}
