namespace ECom.Shared.Entities;

[Table("Suppliers", Schema = "ECPrivate")]
public class Supplier : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }
  

  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  public string Name { get; set; }

  [MinLength(ValidationSettings.MinDescriptionLength)]
  [MaxLength(ValidationSettings.MaxDescriptionLength)]
  public string Description { get; set; }

  [MaxLength(ValidationSettings.MaxNameLength)]
  public string CompanyName { get; set; }

  [MinLength(ValidationSettings.MinPhoneLength)]
  [MaxLength(ValidationSettings.MaxPhoneLength)]
  public string PhoneNumber { get; set; }

  [EmailAddress]
  [MaxLength(ValidationSettings.MaxEmailLength)]
  public string EmailAddress { get; set; }

  public virtual List<StockChange> StockChanges { get; set; }
}