namespace ECom.Domain.Entities;

[Table("CategoryDiscounts", Schema = "ECPrivate")]
public class CategoryDiscount : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? DeleteDate { get; set; }
  public DateTime EndDate { get; set; }
  public float DiscountPercent { get; set; }
  public string CategoryId { get; set; }

  public virtual Category Category { get; set; }
}