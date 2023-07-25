namespace ECom.Shared.Entities;

[Table("CompanyInformation", Schema = "ECOperation")]
public class CompanyInformation : IEntity
{
  [Key]
  public bool Key { get; set; } = true;

  [MaxLength(ValidationSettings.MaxDomainLength)]
  public string DomainUrl { get; set; } = "https://";


  [MaxLength(ValidationSettings.MaxDomainLength)]
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
  public string ContactEmail { get; set; } = "contact@mail.com";

  [MaxLength(ValidationSettings.MaxPhoneLength)]
  [MinLength(ValidationSettings.MinPhoneLength)]
  public string? WhatsApp { get; set; } 


  [MaxLength(ValidationSettings.MaxDomainLength)]

  public string? FacebookLink { get; set; }

  [MaxLength(ValidationSettings.MaxDomainLength)]

  public string? InstagramLink { get; set; }

  [MaxLength(ValidationSettings.MaxDomainLength)]

  public string? YoutubeLink { get; set; }

  
  public Guid? LogoImageId { get; set; }
  public Guid? FavIcoImageId { get; set; }
}