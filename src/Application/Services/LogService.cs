
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Services
{
	public interface ILogService 
	{
	}
	public class LogService : ILogService
	{
		private readonly IEfEntityRepository<UserLog> _userLogRepo;
		private readonly IEfEntityRepository<SecurityLog> _securityLogRepo;
		private readonly IEfEntityRepository<AdminLog> _adminLogRepo;

		public LogService(
			IEfEntityRepository<UserLog> userLogRepo,
			IEfEntityRepository<SecurityLog> securityLogRepo,
			IEfEntityRepository<AdminLog> adminLogRepo)
		{
			this._userLogRepo = userLogRepo;
			this._securityLogRepo = securityLogRepo;
			this._adminLogRepo = adminLogRepo;
		}
	}
}
