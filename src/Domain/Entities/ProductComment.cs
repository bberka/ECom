namespace ECom.Domain.Entities;

[Table("ProductComments", Schema = "ECPrivate")]
public class ProductComment : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

  public int Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.Now;

  [MaxLength(1000)]
  [MinLength(8)]
  public string Comment { get; set; }

  public byte Star { get; set; }

  //FK
  public int UserId { get; set; }
  public int ProductId { get; set; }
}