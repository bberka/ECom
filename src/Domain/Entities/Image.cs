

namespace ECom.Domain.Entities;

[Table("Images", Schema = "ECPrivate")]
public class Image : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  [MaxLength(ValidationSettings.MaxNameLength)]
  public string Name { get; set; }
  public byte[] Data { get; set; }

  [MaxLength(ValidationSettings.MaxCultureLength)]
  [MinLength(ValidationSettings.MinCultureLength)]
  public string Culture { get; set; }
  
}