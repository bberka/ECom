namespace ECom.Shared.Entities;

[PrimaryKey(nameof(UserId), nameof(ProductId))]
[Table("DiscountNotifies", Schema = "ECPrivate")]
public class DiscountNotify : IEntity
{
  public Guid UserId { get; set; }
  public Guid ProductId { get; set; }
  public virtual User User { get; set; }
  public virtual Product Product { get; set; }
}