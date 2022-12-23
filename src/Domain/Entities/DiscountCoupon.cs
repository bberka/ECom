using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class DiscountCoupon
	{
		[Key]
		public string Id { get; set; }

		[Required]
		public DateTime RegisterDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }

		[Required]
		[Range(0, 100)]
		public byte DiscountPercent { get; set; }

		[ForeignKey("Category")]
		[Required]
		public int DiscountCategory { get; set; }


	}
}
