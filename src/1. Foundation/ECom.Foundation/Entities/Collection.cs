﻿using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("Collections", Schema = "ECPrivate")]
public class Collection : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  public string Name { get; set; }

  public Guid UserId { get; set; }

  //Virtual
  public virtual User User { get; set; }
}