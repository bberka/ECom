namespace ECom.Foundation.Entities;

[Table("ProductDetails", Schema = "ECPrivate")]
public class ProductDetail : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public Guid NameLanguageKey { get; set; }
  public Guid ShortDescriptionLanguageKey { get; set; }
  public Guid DescriptionMarkdownLanguageKey { get; set; }
}