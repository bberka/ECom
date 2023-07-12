namespace ECom.Domain.Entities;

[Table("ShowCaseImages", Schema = "ECPrivate")]
public class ShowCaseImage : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.Now;

  public bool IsValid { get; set; } = true;

  public byte Order { get; set; }

  /// <summary>
  ///   0: Right Side (Home Page)
  ///   1: Left Side (Home Page)
  ///   2: Discounts
  ///   3: Good Deals
  /// </summary>
  public byte ShowCaseType { get; set; }

  public int ImageId { get; set; }


  //virtual
  public virtual Image Image { get; set; }
}