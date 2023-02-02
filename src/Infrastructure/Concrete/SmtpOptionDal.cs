using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Infrastructure.Concrete
{
	public class SmtpOptionDal : EfEntityRepositoryBase<SmtpOption, EComDbContext>
	{

		private SmtpOptionDal() { }
		public static SmtpOptionDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static SmtpOptionDal? Instance;
	}
}
