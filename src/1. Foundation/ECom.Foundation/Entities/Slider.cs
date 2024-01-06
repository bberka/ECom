using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("Sliders", Schema = "ECPrivate")]
public class Slider : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  [MaxLength(StaticValues.MAX_TITLE_LENGTH)]
  public string Title { get; set; }

  [MaxLength(StaticValues.MAX_IMAGE_ALT_LENGTH)]
  public string Alt { get; set; }

  public int Order { get; set; }

  public Guid ImageId { get; set; }

  public CultureType Culture { get; set; } = StaticValues.DEFAULT_LANGUAGE;


  //virtual
  public virtual Image Image { get; set; }
}