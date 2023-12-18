namespace ECom.Foundation.Entities;

[PrimaryKey(nameof(ProductId), nameof(CollectionId))]
[Table("CollectionProducts", Schema = "ECPrivate")]
public class CollectionProduct : IEntity
{
  public Guid ProductId { get; set; }
  public Guid CollectionId { get; set; }

  //virtual
  public virtual Product Product { get; set; }
  public virtual Collection Collection { get; set; }
}