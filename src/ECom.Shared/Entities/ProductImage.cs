namespace ECom.Shared.Entities;

[Table("ProductImages", Schema = "ECPrivate")]
[PrimaryKey(nameof(ProductId), nameof(ImageId))]
public class ProductImage : IEntity
{
  public Guid ProductId { get; set; }
  public Guid ImageId { get; set; }
  public virtual Product Product { get; set; }
  public virtual Image Image { get; set; }
}

