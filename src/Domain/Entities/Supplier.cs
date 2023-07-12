namespace ECom.Domain.Entities;

public class Supplier : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  public DateTime RegisterDate { get; set; }

  [MinLength(ConstantMgr.NameMinLength)]
  [MaxLength(ConstantMgr.NameMaxLength)]
  public string Name { get; set; }

  [MaxLength(128)]
  public string Description { get; set; }

  [MaxLength(128)]
  public string CompanyName { get; set; }

  [MinLength(ConstantMgr.PhoneNumberMinLength)]
  [MaxLength(ConstantMgr.PhoneNumberMaxLength)]
  public string PhoneNumber { get; set; }

  [MaxLength(ConstantMgr.EmailMaxLength)]
  [EmailAddress]
  public string EmailAddress { get; set; }

  public virtual List<StockChange> StockChanges { get; set; }
}