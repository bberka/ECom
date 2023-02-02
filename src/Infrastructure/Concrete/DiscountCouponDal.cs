
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Concrete
{
	public class DiscountCouponDal : EfEntityRepositoryBase<DiscountCoupon, EComDbContext>
	{
		private DiscountCouponDal() { }
		public static DiscountCouponDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static DiscountCouponDal? Instance;

	}
}
