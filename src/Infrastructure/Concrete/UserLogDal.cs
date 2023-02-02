
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Concrete
{
	public class UserLogDal : EfEntityRepositoryBase<UserLog, EComDbContext>
	{

		private UserLogDal() { }
		public static UserLogDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static UserLogDal? Instance;
	}
}
