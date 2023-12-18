namespace ECom.Foundation.Entities;

[Table("Addresses", Schema = "ECPrivate")]
public class Address : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string Name { get; set; }

  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string Surname { get; set; }

  [MaxLength(ConstantContainer.MaxTitleLength)]
  public string Title { get; set; }

  [MaxLength(ConstantContainer.MaxCityLength)]
  [MinLength(ConstantContainer.MinCityLength)]
  public string Town { get; set; }

  [MaxLength(ConstantContainer.MaxCountryLength)]
  [MinLength(ConstantContainer.MinCountryLength)]
  public string Country { get; set; }

  [MaxLength(ConstantContainer.MaxCityLength)]
  [MinLength(ConstantContainer.MinCityLength)]
  public string Provience { get; set; }

  [MaxLength(ConstantContainer.MaxAddressLength)]
  [MinLength(ConstantContainer.MinAddressLength)]
  public string Details { get; set; }

  [MinLength(ConstantContainer.MinPhoneLength)]
  [MaxLength(ConstantContainer.MaxPhoneLength)]
  public string PhoneNumber { get; set; }

  //FK
  public Guid UserId { get; set; }
}