namespace ECom.Domain.Entities;

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

  [MaxLength(ValidationSettings.MaxCouponLength)]
  [MinLength(ValidationSettings.MinCouponLength)]
  public string Coupon { get; set; }

}