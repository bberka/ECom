using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.BaseManager
{
	public class ProductCommentImageBindMgr : EfEntityRepositoryBase<ProductCommentImageBind, EComDbContext>
	{

		private ProductCommentImageBindMgr() { }
		public static ProductCommentImageBindMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static ProductCommentImageBindMgr? Instance;
	}
}
