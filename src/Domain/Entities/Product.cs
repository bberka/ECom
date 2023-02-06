using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
	public class Product : IEfEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public bool IsValid { get; set; }
		public DateTime RegisterDate { get; set; }
		public DateTime? DeleteDate { get; set; }
		public bool IsLimited { get; set; }
		public decimal DiscountedPriceIncludingTax { get; set; }
        public decimal OriginalPriceIncludingTax { get; set; }
        public decimal Tax { get; set; }

        [ForeignKey("ProductVariantId")]
        public int? ProductVariantId { get; set; }
        public virtual ProductVariant? Variant { get; set; }


	}
}
