
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.BaseManager
{
	public class SecurityLogMgr : EfEntityRepositoryBase<SecurityLog, EComDbContext>
	{

		private SecurityLogMgr() { }
		public static SecurityLogMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static SecurityLogMgr? Instance;
	}
}
