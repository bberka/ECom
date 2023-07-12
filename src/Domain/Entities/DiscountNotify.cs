﻿namespace ECom.Domain.Entities;

[PrimaryKey(nameof(UserId), nameof(ProductId))]
[Table("DiscountNotifies", Schema = "ECPrivate")]
public class DiscountNotify : IEntity
{
  public int UserId { get; set; }
  public int ProductId { get; set; }


  public virtual User User { get; set; }
  public virtual Product Product { get; set; }
}