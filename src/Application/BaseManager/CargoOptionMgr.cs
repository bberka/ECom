using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.BaseManager
{
    public class CargoOptionMgr : EfEntityRepositoryBase<BasketProduct, EComDbContext>
	{

		private CargoOptionMgr() { }
		public static CargoOptionMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static CargoOptionMgr? Instance;
	}
}
