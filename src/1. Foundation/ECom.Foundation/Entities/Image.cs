using ECom.Foundation.Enum;

namespace ECom.Foundation.Entities;

[Table("Images", Schema = "ECPrivate")]
public class Image : IEntity
{
  public const string LocKey = "image";

  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;

  [MaxLength(ConstantContainer.MaxNameLength)]
  public string Name { get; set; }

  [MaxLength(ConstantContainer.MaxExtensionLength)]
  public string FileExtension { get; set; }

  public long Size { get; set; } = 0;


  public Language Culture { get; set; } = ConstantContainer.DefaultLanguage;


  [MaxLength(ConstantContainer.MaxContentTypeHeaderLength)]
  public string ContentType { get; set; }
}