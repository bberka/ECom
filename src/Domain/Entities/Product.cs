namespace ECom.Domain.Entities
{
	public class Product : IEfEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public bool IsValid { get; set; }
		public DateTime RegisterDate { get; set; } = DateTime.Now;
		public DateTime? DeleteDate { get; set; }
		public decimal DiscountedPriceIncludingTax { get; set; }
        public decimal OriginalPriceIncludingTax { get; set; }
        public decimal Tax { get; set; }
        public int? ProductVariantId { get; set; }

		//virtual
        public virtual ProductVariant? ProductVariant { get; set; }
        public virtual List<ProductComment> ProductComments { get; set; }
		public virtual List<ProductImage> ProductImages { get; set; }
		public virtual List<ProductDetail> ProductDetails { get; set; }
        public virtual double StarScore => ProductComments.Average(x => x.Star);
        public virtual List<StockChange> StockChanges { get; set; }

    }
}
