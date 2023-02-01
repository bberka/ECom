
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.BaseManager
{
	public class UserLogMgr : EfEntityRepositoryBase<UserLog, EComDbContext>
	{

		private UserLogMgr() { }
		public static UserLogMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static UserLogMgr? Instance;
	}
}
