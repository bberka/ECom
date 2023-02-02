using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Infrastructure.Concrete
{
	public class SliderDal : EfEntityRepositoryBase<Slider, EComDbContext>
	{

		private SliderDal() { }
		public static SliderDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static SliderDal? Instance;
	}
}
