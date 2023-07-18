using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ECom.Domain.Entities;

[Table("StockChanges", Schema = "ECPrivate")]
public class StockChange : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.Now;

  /// <summary>
  ///   0: Decrease
  ///   1: Create
  /// </summary>
  public bool Type { get; set; }

  public int Count { get; set; }
  public int Cost { get; set; }
  public int ProductId { get; set; }
  public int? SupplierId { get; set; }
  public int? OrderId { get; set; }
  public string? Reason { get; set; }

  //virtual
  [IgnoreDataMember]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  public virtual Supplier Supplier { get; set; }

  [IgnoreDataMember]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  public virtual Product Product { get; set; }

  [IgnoreDataMember]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  public virtual User User { get; set; }
}