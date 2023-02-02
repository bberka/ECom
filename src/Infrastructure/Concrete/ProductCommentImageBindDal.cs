using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Infrastructure.Concrete
{
	public class ProductCommentImageBindDal : EfEntityRepositoryBase<ProductCommentImageBind, EComDbContext>
	{

		private ProductCommentImageBindDal() { }
		public static ProductCommentImageBindDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static ProductCommentImageBindDal? Instance;
	}
}
