namespace ECom.Domain.Entities;

[Table("ProductDetails", Schema = "ECPrivate")]
public class ProductDetail : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  [MinLength(ConstantMgr.NameMinLength)]
  [MaxLength(ConstantMgr.NameMaxLength)]
  public string Name { get; set; }


  [MaxLength(512)]
  [MinLength(8)]
  public string ShortDescription { get; set; }


  [MaxLength(10000)]
  [MinLength(64)]
  public string DescriptionHTML { get; set; }

  [MaxLength(10000)]
  [MinLength(32)]
  public string? TechnicalInformationHTML { get; set; }

  public int ProductId { get; set; }


  [MinLength(2)]
  [MaxLength(4)]
  public string Culture { get; set; } = ConstantMgr.DefaultCulture;


  //virtual
  public virtual Product Product { get; set; }
}