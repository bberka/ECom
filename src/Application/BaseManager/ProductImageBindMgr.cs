using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.BaseManager
{
	public class ProductImageBindMgr : EfEntityRepositoryBase<ProductImageBind, EComDbContext>
	{

		private ProductImageBindMgr() { }
		public static ProductImageBindMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static ProductImageBindMgr? Instance;
	}
}
