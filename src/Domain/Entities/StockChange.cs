using EasMe.EntityFrameworkCore;

namespace ECom.Domain.Entities;

[Table("StockChanges", Schema = "ECPrivate")]
public class StockChange : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? DeleteDate { get; set; }
  public StockChangeType Type { get; set; }

  public int Count { get; set; }
  public decimal Cost { get; set; }
  public Guid ProductId { get; set; }
  public Guid? SupplierId { get; set; }
  public Guid? OrderId { get; set; }
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