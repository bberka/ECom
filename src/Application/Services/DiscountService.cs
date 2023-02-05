
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Services
{

	public class DiscountService : IDiscountService
	{
		private readonly IEfEntityRepository<CategoryDiscount> _categoryDiscountRepo;
		private readonly IEfEntityRepository<DiscountCoupon> _discountCouponRepo;
		private readonly IEfEntityRepository<DiscountNotify> _discountNotifyRepo;

		public DiscountService(
			IEfEntityRepository<CategoryDiscount> categoryDiscountRepo,
			IEfEntityRepository<DiscountCoupon> discountCouponRepo,
			IEfEntityRepository<DiscountNotify> discountNotifyRepo)
		{
			this._categoryDiscountRepo = categoryDiscountRepo;
			this._discountCouponRepo = discountCouponRepo;
			this._discountNotifyRepo = discountNotifyRepo;
		}
	
	}
	
}
