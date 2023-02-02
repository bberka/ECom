
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Concrete
{
    public class ProductCommentDal : EfEntityRepositoryBase<ProductComment, EComDbContext>
	{

		private ProductCommentDal() { }
		public static ProductCommentDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static ProductCommentDal? Instance;
	}
}
