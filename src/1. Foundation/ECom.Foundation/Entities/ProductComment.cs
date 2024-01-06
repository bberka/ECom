using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("ProductComments", Schema = "ECPrivate")]
public class ProductComment : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;

  public bool IsApproved { get; set; } = false;
  public bool IsHidden { get; set; } = false;
  public bool IsShowComment => IsApproved && !IsHidden;

  [MaxLength(StaticValues.MAX_PRODUCT_COMMENT_LENGTH)]
  [MinLength(StaticValues.MIN_PRODUCT_COMMENT_LENGTH)]
  public string Comment { get; set; }

  [Range(0, 5)]
  public byte Star { get; set; }

  //FK
  public Guid UserId { get; set; }
  public Guid ProductId { get; set; }
  public virtual User User { get; set; }
  public virtual Product Product { get; set; }
}