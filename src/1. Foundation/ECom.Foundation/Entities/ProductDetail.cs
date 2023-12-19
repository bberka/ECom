namespace ECom.Foundation.Entities;

[Table("ProductDetails", Schema = "ECPrivate")]
public class ProductDetail : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public Guid NameContentId { get; set; }
  public Guid ShortDescriptionContentId { get; set; }
  public Guid DescriptionMarkdownContentId { get; set; }
}