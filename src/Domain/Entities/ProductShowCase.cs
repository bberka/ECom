namespace ECom.Domain.Entities;

public class ProductShowCase : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.Now;

  public bool IsValid { get; set; }

  public byte Order { get; set; }

  /// <summary>
  ///   0: Right Side (Home Page)
  ///   1: Left Side (Home Page)
  ///   2: Discounts
  ///   3: Good Deals
  /// </summary>
  public byte ShowCaseType { get; set; }

  public int ProductId { get; set; }

  //virtual
  public virtual Product Product { get; set; }
}