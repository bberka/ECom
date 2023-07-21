using EasMe.EntityFrameworkCore;

namespace ECom.Domain.Entities;

[Table("Sliders", Schema = "ECPrivate")]
public class Slider : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  [MaxLength(ValidationSettings.MaxTitleLength)]
  public string Title { get; set; }

  [MaxLength(ValidationSettings.MaxImageAltLength)]
  public string Alt { get; set; }
  
  public int Order { get; set; }
  
  public Guid ImageId { get; set; }

  [MinLength(ValidationSettings.MinCultureLength)]
  [MaxLength(ValidationSettings.MaxCultureLength)]
  public string Culture { get; set; } = ConstantMgr.DefaultCulture;
  
  //virtual
  public virtual Image Image { get; set; }
}