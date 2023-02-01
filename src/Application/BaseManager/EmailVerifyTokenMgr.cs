
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.BaseManager
{
	public class EmailVerifyTokenMgr : EfEntityRepositoryBase<EmailVerifyToken, EComDbContext>
	{

		private EmailVerifyTokenMgr() { }
		public static EmailVerifyTokenMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static EmailVerifyTokenMgr? Instance;
	}
}
