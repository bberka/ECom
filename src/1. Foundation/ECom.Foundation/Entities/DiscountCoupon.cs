using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("DiscountCoupons", Schema = "ECPrivate")]
[Index(nameof(Coupon))]
public class DiscountCoupon : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? DeleteDate { get; set; }
  public DateTime EndDate { get; set; }

  public float DiscountPercent { get; set; }

  [MaxLength(StaticValues.MAX_COUPON_LENGTH)]
  [MinLength(StaticValues.MIN_COUPON_LENGTH)]
  public string Coupon { get; set; }
}