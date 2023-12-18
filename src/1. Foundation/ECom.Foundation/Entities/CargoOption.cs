namespace ECom.Foundation.Entities;

[Table("CargoOptions", Schema = "ECOption")]
public class CargoOption : IEntity
{
  public const string LocKey = "cargo_option";

  [Key]

  public Guid Id { get; set; }


  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;


  public DateTime? UpdateDate { get; set; }

  public DateTime? DeleteDate { get; set; }

  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]

  public string Name { get; set; }

  public int FreeShippingMinLimit { get; set; }

  [ForeignKey("ImageId")]
  public Guid ImageId { get; set; }

  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  public virtual Image Image { get; set; }
}