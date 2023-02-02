using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Concrete
{
	public class AdminLogDal : EfEntityRepositoryBase<AdminLog, EComDbContext>
	{

		private AdminLogDal() { }
		public static AdminLogDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static AdminLogDal? Instance;
	}
}
