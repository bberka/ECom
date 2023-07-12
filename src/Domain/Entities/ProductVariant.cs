﻿namespace ECom.Domain.Entities;

[Table("ProductVariants", Schema = "ECPrivate")]
public class ProductVariant : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  [MaxLength(256)]
  public string Description { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.Now;
}