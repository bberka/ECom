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

		public DateTime RegisterDate { get; set; }

		public DateTime? DeleteDate { get; set; }
		public DateTime? StockEndDate { get; set; }

		public bool IsLimited { get; set; }

		public int SoldCount { get; set; }

		public int StockCount { get; set; }

		public double DiscountedPriceIncludingTax { get; set; }

        public double OriginalPriceIncludingTax { get; set; }
        public double Tax { get; set; }

        [ForeignKey("ProductVariantId")]
        public int? ProductVariantId { get; set; }
        public virtual ProductVariant? Variant { get; set; }

        [ForeignKey("SubCategoryId")]
        public int? SubCategoryId { get; set; }
        public virtual SubCategory? Category { get; set; }
		public List<ProductDetails> Details { get; set; } = new();
		public List<ProductComment> Comments { get; set; } = new();
		public List<Product> Variants { get; set; } = new();

	}
}
