namespace ECom.Domain.Entities;

public class Slider : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.Now;
  public DateTime? DeleteDate { get; set; }

  [MaxLength(50)]
  public string Title { get; set; }

  [MaxLength(50)]
  public string Alt { get; set; }


  public int Order { get; set; }

  [ForeignKey(nameof(Image))]
  public int ImageId { get; set; }

  [MinLength(2)]
  [MaxLength(4)]
  public string Culture { get; set; } = ConstantMgr.DefaultCulture;


  //virtual
  public virtual Image Image { get; set; }
}