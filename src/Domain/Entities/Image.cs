namespace ECom.Domain.Entities;

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
}