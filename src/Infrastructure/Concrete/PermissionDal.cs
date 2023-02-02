
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Concrete
{
	public class PermissionDal : EfEntityRepositoryBase<Permission, EComDbContext>
	{

		private PermissionDal() { }
		public static PermissionDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static PermissionDal? Instance;
	}
}
