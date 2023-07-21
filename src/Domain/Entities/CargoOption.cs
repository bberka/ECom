using EasMe.EntityFrameworkCore;

namespace ECom.Domain.Entities;

[Table("CargoOptions", Schema = "ECOption")]
public class CargoOption : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  public string Name { get; set; }

  public int FreeShippingMinCost { get; set; }

  [ForeignKey("ImageId")]
  public Guid ImageId { get; set; }

  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  public virtual Image Image { get; set; }
}