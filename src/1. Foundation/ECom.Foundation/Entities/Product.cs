namespace ECom.Foundation.Entities;

[Table("Products", Schema = "ECPrivate")]
public class Product : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  public long Stock { get; set; }
  public double Price { get; set; }
  public double? DiscountedPrice { get; set; }

  //FK
  public Guid ProductVariantId { get; set; }
  public Guid ProductDetailId { get; set; }

  public virtual ProductVariant ProductVariant { get; set; }
  public virtual ProductDetail ProductDetail { get; set; }

  public virtual List<ProductAttribute> ProductAttributes { get; set; }
  public virtual List<ProductComment> ProductComments { get; set; }
  public virtual List<ProductImage> ProductImages { get; set; }
  public virtual List<StockChange> StockChanges { get; set; }
  public virtual double StarScore => ProductComments?.Average(x => x.Star) ?? 0;
}