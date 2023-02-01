
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.BaseManager
{
	public class PasswordResetTokenMgr : EfEntityRepositoryBase<PasswordResetToken, EComDbContext>
	{

		private PasswordResetTokenMgr() { }
		public static PasswordResetTokenMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static PasswordResetTokenMgr? Instance;
	}
}
