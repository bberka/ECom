using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
	public class Order : IEfEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public DateTime RegisterDate { get; set; }

		public double OriginalPrice { get; set; }

		public double? DiscountedPrice { get; set; }

		[MaxLength(64)]
		public string? Ip { get; set; }

        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        [ForeignKey("DiscountCouponId")]
        public int? DiscountCouponId { get; set; }
        public virtual DiscountCoupon? DiscountCoupon { get; set; }

        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
