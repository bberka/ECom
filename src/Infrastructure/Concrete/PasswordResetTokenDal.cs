
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Concrete
{
	public class PasswordResetTokenDal : EfEntityRepositoryBase<PasswordResetToken, EComDbContext>
	{

		private PasswordResetTokenDal() { }
		public static PasswordResetTokenDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static PasswordResetTokenDal? Instance;
	}
}
