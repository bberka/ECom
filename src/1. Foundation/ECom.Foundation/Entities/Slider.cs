using ECom.Foundation.Enum;

namespace ECom.Foundation.Entities;

[Table("Sliders", Schema = "ECPrivate")]
public class Slider : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  [MaxLength(ConstantContainer.MaxTitleLength)]
  public string Title { get; set; }

  [MaxLength(ConstantContainer.MaxImageAltLength)]
  public string Alt { get; set; }

  public int Order { get; set; }

  public Guid ImageId { get; set; }

  public LanguageType Culture { get; set; } = ConstantContainer.DefaultLanguage;


  //virtual
  public virtual Image Image { get; set; }
}