using EasMe.EntityFrameworkCore;

namespace ECom.Domain.Entities;

[Table("Addresses", Schema = "ECPrivate")]
public class Address : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  public string Name { get; set; }

  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  public string Surname { get; set; }

  [MaxLength(ValidationSettings.MaxTitleLength)]
  public string Title { get; set; }

  [MaxLength(ValidationSettings.MaxCityLength)]
  [MinLength(ValidationSettings.MinCityLength)]
  public string Town { get; set; }

  [MaxLength(ValidationSettings.MaxCountryLength)]
  [MinLength(ValidationSettings.MinCountryLength)]
  public string Country { get; set; }

  [MaxLength(ValidationSettings.MaxCityLength)]
  [MinLength(ValidationSettings.MinCityLength)]
  public string Provience { get; set; }

  [MaxLength(ValidationSettings.MaxAddressLength)]
  [MinLength(ValidationSettings.MinAddressLength)]
  public string Details { get; set; }

  [MinLength(ValidationSettings.MinPhoneLength)]
  [MaxLength(ValidationSettings.MaxPhoneLength)]
  public string PhoneNumber { get; set; }

  //FK
  public Guid UserId { get; set; }
  
}