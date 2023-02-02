
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Concrete
{
	public class ImageDal : EfEntityRepositoryBase<Image, EComDbContext>
	{

		private ImageDal() { }
		public static ImageDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static ImageDal? Instance;
	}
}
