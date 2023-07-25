namespace ECom.Shared.Entities;

[PrimaryKey(nameof(UserId), nameof(ProductId))]
[Table("Carts", Schema = "ECPrivate")]
public class Cart : IEntity
{

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }
  public int Count { get; set; }
  public Guid UserId { get; set; }
  public Guid ProductId { get; set; }


  //Virtual
  public virtual Product Product { get; set; }
  public virtual User User { get; set; }
}