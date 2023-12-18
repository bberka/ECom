namespace ECom.Foundation.Entities;

[Table("Suppliers", Schema = "ECPrivate")]
public class Supplier : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }


  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string Name { get; set; }

  [MinLength(ConstantContainer.MinDescriptionLength)]
  [MaxLength(ConstantContainer.MaxDescriptionLength)]
  public string Description { get; set; }

  [MaxLength(ConstantContainer.MaxNameLength)]
  public string CompanyName { get; set; }

  [MinLength(ConstantContainer.MinPhoneLength)]
  [MaxLength(ConstantContainer.MaxPhoneLength)]
  public string PhoneNumber { get; set; }

  [EmailAddress]
  [MaxLength(ConstantContainer.MaxEmailLength)]
  public string EmailAddress { get; set; }

  public virtual List<StockChange> StockChanges { get; set; }
}