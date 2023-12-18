namespace ECom.Foundation.Entities;

[Table("CompanyInformation", Schema = "ECOption")]
public class CompanyInformation : IEntity,
                                  ICloneable
{
  public const string LocKey = "company_information";
  public const bool SingleKey = true;

  [Key]
  public bool Key { get; set; } = true;

  [MaxLength(ConstantContainer.MaxDomainLength)]
  [Url]

  public string WebUiUrl { get; set; } = "https://shop.zdk.network";

  [MaxLength(ConstantContainer.MaxDomainLength)]
  [Url]
  public string AdminPanelUrl { get; set; } = "https://panel.shop.zdk.network";


  [MaxLength(ConstantContainer.MaxNameLength)]

  public string CompanyName { get; set; } = "CompanyName";

  [MaxLength(ConstantContainer.MaxDescriptionLength)]
  public string Description { get; set; } = "Description";

  [MaxLength(ConstantContainer.MaxAddressLength)]
  [MinLength(ConstantContainer.MinAddressLength)]
  public string CompanyAddress { get; set; }

  [MaxLength(ConstantContainer.MaxPhoneLength)]
  [MinLength(ConstantContainer.MinPhoneLength)]
  public string? PhoneNumber { get; set; }

  [EmailAddress]
  [MaxLength(ConstantContainer.MaxEmailLength)]
  public string ContactEmail { get; set; } = "contact@mail.com";

  [MaxLength(ConstantContainer.MaxPhoneLength)]
  [MinLength(ConstantContainer.MinPhoneLength)]
  [Phone]
  public string? WhatsApp { get; set; }


  [MaxLength(ConstantContainer.MaxDomainLength)]
  [Url]
  public string? FacebookLink { get; set; }

  [MaxLength(ConstantContainer.MaxDomainLength)]
  [Url]
  public string? InstagramLink { get; set; }

  [MaxLength(ConstantContainer.MaxDomainLength)]
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