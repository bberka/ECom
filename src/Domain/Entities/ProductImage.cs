namespace ECom.Domain.Entities;

[Table("ProductImages", Schema = "ECPrivate")]
[PrimaryKey(nameof(ProductId), nameof(ImageId))]
public class ProductImage : IEntity
{
  public int ProductId { get; set; }
  public int ImageId { get; set; }
  public virtual Product Product { get; set; }
  public virtual Image Image { get; set; }
}

