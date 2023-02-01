using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ECom.Infrastructure.Abstract;

namespace ECom.Application.BaseManager
{
	public class AdminMgr : EfEntityRepositoryBase<Admin, EComDbContext>, IEfAdmin
	{
		private AdminMgr() { }
		public static AdminMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static AdminMgr? Instance;
		public bool HasPermission(int adminId, int permissionId)
		{
			var ctx = new EComDbContext();
			var admin = GetSingle(x => x.Id == adminId && x.IsValid == true && x.IsEmailVerified == true && x.DeletedDate != null);
			if (admin.RoleId is null) throw new BaseException(Response.DbErrorForeignKeyIsInvalid);
			return RoleBindMgr.This.Any(x => x.PermissionId == permissionId && x.RoleId == admin.RoleId && x.IsValid == true);
		}
		
	}
}
