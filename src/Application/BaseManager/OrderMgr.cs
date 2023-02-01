using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.BaseManager
{
	public class OrderMgr : EfEntityRepositoryBase<Order, EComDbContext>
	{

		private OrderMgr() { }
		public static OrderMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static OrderMgr? Instance;
	}
}
