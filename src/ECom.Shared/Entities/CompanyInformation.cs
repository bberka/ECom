namespace ECom.Shared.Entities;

[Table("CompanyInformation", Schema = "ECOperation")]
public class CompanyInformation : IEntity, ICloneable
{

  public const string LocKey = "company_information";

  [Key]
  public bool Key { get; set; } = true;

  [MaxLength(ValidationSettings.MaxDomainLength)]
  [Url]

  public string DomainUrl { get; set; } = "https://";


  [MaxLength(ValidationSettings.MaxDomainLength)]
  [Url]

  public string WebApiUrl { get; set; } = "https://";


  [MaxLength(ValidationSettings.MaxNameLength)]
  public string CompanyName { get; set; } = "CompanyName";

  [MaxLength(ValidationSettings.MaxDescriptionLength)]
  public string Description { get; set; } = "Description";

  [MaxLength(ValidationSettings.MaxAddressLength)]
  [MinLength(ValidationSettings.MinAddressLength)]
  public string CompanyAddress { get; set; }

  [MaxLength(ValidationSettings.MaxPhoneLength)]
  [MinLength(ValidationSettings.MinPhoneLength)]
  public string PhoneNumber { get; set; } = "00000000000";

  [EmailAddress]
  [MaxLength(ValidationSettings.MaxEmailLength)]
  public string ContactEmail { get; set; } = "contact@mail.com";

  [MaxLength(ValidationSettings.MaxPhoneLength)]
  [MinLength(ValidationSettings.MinPhoneLength)]
  [Phone]
  public string? WhatsApp { get; set; } 


  [MaxLength(ValidationSettings.MaxDomainLength)]
  [Url]
  public string? FacebookLink { get; set; }

  [MaxLength(ValidationSettings.MaxDomainLength)]
  [Url]

  public string? InstagramLink { get; set; }

  [MaxLength(ValidationSettings.MaxDomainLength)]
  [Url]

  public string? YoutubeLink { get; set; }

  
  public Guid? LogoImageId { get; set; }
  public Guid? FavIcoImageId { get; set; }
  public object Clone() {
    return MemberwiseClone();
  }
  public CompanyInformation CloneCast() {
    return (CompanyInformation)MemberwiseClone();
  }
}