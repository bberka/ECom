using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.BaseManager
{
	public class RoleMgr : EfEntityRepositoryBase<Role, EComDbContext>
	{

		private RoleMgr() { }
		public static RoleMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static RoleMgr? Instance;
	}
}
