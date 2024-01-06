using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("Suppliers", Schema = "ECPrivate")]
public class Supplier : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }


  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string Name { get; set; }

  [MinLength(StaticValues.MIN_DESCRIPTION_LENGTH)]
  [MaxLength(StaticValues.MAX_DESCRIPTION_LENGTH)]
  public string Description { get; set; }

  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string CompanyName { get; set; }

  [MinLength(StaticValues.MIN_PHONE_LENGTH)]
  [MaxLength(StaticValues.MAX_PHONE_LENGTH)]
  public string PhoneNumber { get; set; }

  [EmailAddress]
  [MaxLength(StaticValues.MAX_EMAIL_LENGTH)]
  public string EmailAddress { get; set; }

  public virtual List<StockChange> StockChanges { get; set; }
}