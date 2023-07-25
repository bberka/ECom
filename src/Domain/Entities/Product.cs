namespace ECom.Domain.Entities;

[Table("Products", Schema = "ECPrivate")]
public class Product : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }
  public float DiscountedPriceIncludingTax { get; set; }
  public float OriginalPriceIncludingTax { get; set; }
  public float Tax { get; set; }
  public Guid? ProductVariantId { get; set; }

  //virtual
  public virtual ProductVariant? ProductVariant { get; set; }
  public virtual List<ProductComment> ProductComments { get; set; }
  public virtual List<ProductImage> ProductImages { get; set; }
  public virtual List<ProductDetail> ProductDetails { get; set; }
  public virtual double StarScore => ProductComments?.Average(x => x.Star) ?? 0;
  public virtual List<StockChange> StockChanges { get; set; }
}