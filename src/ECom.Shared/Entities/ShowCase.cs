namespace ECom.Shared.Entities;

[Table("ShowCases", Schema = "ECPrivate")]
public class ShowCase : IEntity
{
  [Key]
  public ShowCaseType ShowCaseType { get; set; }
  public Guid ImageId { get; set; }

  //virtual
  public virtual Image Image { get; set; }

  /// <summary>
  /// Link a product to a showcase, if product exists on click redirect to product page
  /// </summary>
  public Guid? ProductId { get; set; }

  //virtual
  public virtual Product? Product { get; set; }

}