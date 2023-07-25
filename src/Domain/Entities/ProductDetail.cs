namespace ECom.Domain.Entities;

[Table("ProductDetails", Schema = "ECPrivate")]
public class ProductDetail : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  public string Name { get; set; }

  [MinLength(ValidationSettings.MinProductShortLength)]
  [MaxLength(ValidationSettings.MaxProductShortLength)]
  public string ShortDescription { get; set; }

  [MinLength(ValidationSettings.MinProductDescriptionLength)]
  public string DescriptionMarkdown { get; set; }

  [MinLength(ValidationSettings.MinProductDescriptionLength)]
  public string? TechnicalInformationMarkdown { get; set; }

  public Guid ProductId { get; set; }

  [MinLength(ValidationSettings.MinCultureLength)]
  [MaxLength(ValidationSettings.MaxCultureLength)]
  public string Culture { get; set; } = ConstantMgr.DefaultCulture;

  //virtual
  public virtual Product Product { get; set; }
}