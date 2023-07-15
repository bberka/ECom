namespace ECom.Domain.Entities;

[Table("Orders", Schema = "ECPrivate")]
public class Order : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  public DateTime RegisterDate { get; set; }

  public double OriginalPrice { get; set; }

  public double? DiscountedPrice { get; set; }

  [MaxLength(64)]
  public string? Ip { get; set; }

  [ForeignKey("UserId")]
  public int UserId { get; set; }

  public virtual User User { get; set; }

  [ForeignKey("DiscountCouponId")]
  public int DiscountCouponId { get; set; }

  public virtual DiscountCoupon DiscountCoupon { get; set; }
  public OrderStatus OrderStatus { get; private set; } = OrderStatus.Pending;

  [ForeignKey("ProductId")]
  public int ProductId { get; set; }

  public virtual Product Product { get; set; }


  
}