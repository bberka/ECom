
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Concrete
{
	public class EmailVerifyTokenDal : EfEntityRepositoryBase<EmailVerifyToken, EComDbContext>
	{

		private EmailVerifyTokenDal() { }
		public static EmailVerifyTokenDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static EmailVerifyTokenDal? Instance;
	}
}
