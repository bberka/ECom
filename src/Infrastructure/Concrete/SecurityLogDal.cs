
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Concrete
{
	public class SecurityLogDal : EfEntityRepositoryBase<SecurityLog, EComDbContext>
	{

		private SecurityLogDal() { }
		public static SecurityLogDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static SecurityLogDal? Instance;
	}
}
