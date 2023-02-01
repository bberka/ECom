
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.BaseManager
{
    public class ProductCommentMgr : EfEntityRepositoryBase<ProductComment, EComDbContext>
	{

		private ProductCommentMgr() { }
		public static ProductCommentMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static ProductCommentMgr? Instance;
	}
}
