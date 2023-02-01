using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.BaseManager
{
    public class RoleBindMgr : EfEntityRepositoryBase<RoleBind, EComDbContext>
	{

		private RoleBindMgr() { }
		public static RoleBindMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static RoleBindMgr? Instance;
	}
}
