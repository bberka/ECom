namespace ECom.Domain.Entities;

[Table("ProductComments", Schema = "ECPrivate")]
public class ProductComment : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;

  [MaxLength(ValidationSettings.MaxProductCommentLength)]
  [MinLength(ValidationSettings.MinProductCommentLength)]
  public string Comment { get; set; }

  [Range(0,5)]
  public byte Star { get; set; }

  //FK
  public Guid UserId { get; set; }
  public Guid ProductId { get; set; }
  public virtual User User { get; set; }
  public virtual Product Product { get; set; }
}