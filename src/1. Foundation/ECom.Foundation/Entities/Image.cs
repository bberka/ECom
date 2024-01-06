using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("Images", Schema = "ECPrivate")]
public class Image : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;

  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string Name { get; set; }

  [MaxLength(StaticValues.MAX_EXTENSION_LENGTH)]
  public string FileExtension { get; set; }

  public long Size { get; set; } = 0;


  public CultureType Culture { get; set; } = StaticValues.DEFAULT_LANGUAGE;


  [MaxLength(StaticValues.MAX_CONTENT_TYPE_HEADER_LENGTH)]
  public string ContentType { get; set; }
}