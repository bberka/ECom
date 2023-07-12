namespace ECom.Domain.Entities;

[Table("CategoryDiscounts", Schema = "ECPrivate")]
public class CategoryDiscount : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.Now;

  public DateTime EndDate { get; set; }

  [Range(0, 100)]
  public byte DiscountPercent { get; set; }

  [ForeignKey("CategoryId")]
  public int CategoryId { get; set; }

  //virtual
  public virtual Category Category { get; set; }
}