  namespace ECom.Domain.Entities;

[Table("Images", Schema = "ECPrivate")]
public class Image : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  [MaxLength(1000)]
  public string Name { get; set; }

  public byte[] Data { get; set; }

  [MaxLength(2)]
  [MinLength(2)]
  public string Culture { get; set; }

  //public virtual List<Product>? Products { get; set; }
}