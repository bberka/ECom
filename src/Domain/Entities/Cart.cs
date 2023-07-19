using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECom.Domain.Entities;

[PrimaryKey(nameof(UserId), nameof(ProductId))]
[Table("Carts", Schema = "ECPrivate")]
public class Cart : IEntity
{
  public DateTime RegisterDate { get; set; } = DateTime.MaxValue;
  public DateTime LastUpdateDate { get; set; }
  public int Count { get; set; }
  public int UserId { get; set; }
  public int ProductId { get; set; }


  //Virtual
  public virtual Product Product { get; set; }
  public virtual User User { get; set; }
}