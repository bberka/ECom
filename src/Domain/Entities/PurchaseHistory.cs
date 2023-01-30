using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class PurchaseHistory
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public DateTime RegisterDate { get; set; }

		[Required]
		[Range(0,1_000_000_000)]
		public int OriginalPrice { get; set; }

		public int? DiscountedPrice { get; set; }

		[MaxLength(64)]
		public string? Ip { get; set; }


        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }


        [ForeignKey("DiscountCouponId")]
        public int? DiscountCouponId { get; set; }
        public virtual DiscountCoupon DiscountCoupon { get; set; }


        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
