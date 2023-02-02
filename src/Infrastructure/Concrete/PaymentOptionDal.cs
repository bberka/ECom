using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Infrastructure.Concrete
{
	public class PaymentOptionDal : EfEntityRepositoryBase<PaymentOption, EComDbContext>
	{

		private PaymentOptionDal() { }
		public static PaymentOptionDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static PaymentOptionDal? Instance;
	}
}
