namespace ECom.Domain.Entities;

[Table("CargoOptions", Schema = "ECOption")]
public class CargoOption : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }


  public bool IsValid { get; set; }


  public string Name { get; set; }


  public int FreeShippingMinCost { get; set; }


  [ForeignKey("ImageId")]
  public int ImageId { get; set; }

  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  public virtual Image Image { get; set; }
}