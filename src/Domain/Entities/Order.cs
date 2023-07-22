

namespace ECom.Domain.Entities;

[Table("Orders", Schema = "ECPrivate")]
public class Order : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public double OriginalPrice { get; set; }
  public double? DiscountedPrice { get; set; }
  public Guid UserId { get; set; }
  public virtual User User { get; set; }
  public Guid DiscountCouponId { get; set; }
  public virtual DiscountCoupon DiscountCoupon { get; set; }
  public OrderStatus OrderStatus { get; } = OrderStatus.Pending;
  public Guid ProductId { get; set; }
  public virtual Product Product { get; set; }
}