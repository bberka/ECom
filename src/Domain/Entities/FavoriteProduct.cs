

namespace ECom.Domain.Entities;

[PrimaryKey(nameof(UserId), nameof(ProductId))]
[Table("FavoriteProducts", Schema = "ECPrivate")]
public class FavoriteProduct : IEntity
{
  public DateTime RegisterDate { get; set; }
  public DateTime UpdateDate { get; set; }
  public Guid UserId { get; set; }
  public Guid ProductId { get; set; }

  //Virtual
  //public virtual User User { get; set; }
  public virtual Product Product { get; set; }
}