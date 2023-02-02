using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Concrete
{
    public class CargoOptionDal : EfEntityRepositoryBase<BasketProduct, EComDbContext>
	{

		private CargoOptionDal() { }
		public static CargoOptionDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static CargoOptionDal? Instance;
	}
}
