using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.BaseManager
{
	public class SmtpOptionMgr : EfEntityRepositoryBase<SmtpOption, EComDbContext>
	{

		private SmtpOptionMgr() { }
		public static SmtpOptionMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static SmtpOptionMgr? Instance;
	}
}
