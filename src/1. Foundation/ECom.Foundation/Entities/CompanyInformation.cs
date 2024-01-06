using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("CompanyInformation", Schema = "ECOption")]
public class CompanyInformation : IEntity,
                                  ICloneable
{
  public const bool SINGLE_KEY = true;

  [Key]
  public bool Key { get; set; } = true;

  [MaxLength(StaticValues.MAX_DOMAIN_LENGTH)]
  [Url]

  public string WebUiUrl { get; set; } = "https://shop.zdk.network";

  [MaxLength(StaticValues.MAX_DOMAIN_LENGTH)]
  [Url]
  public string AdminPanelUrl { get; set; } = "https://panel.shop.zdk.network";


  [MaxLength(StaticValues.MAX_NAME_LENGTH)]

  public string CompanyName { get; set; } = "CompanyName";

  [MaxLength(StaticValues.MAX_DESCRIPTION_LENGTH)]
  public string Description { get; set; } = "Description";

  [MaxLength(StaticValues.MAX_ADDRESS_LENGTH)]
  [MinLength(StaticValues.MIN_ADDRESS_LENGTH)]
  public string CompanyAddress { get; set; }

  [MaxLength(StaticValues.MAX_PHONE_LENGTH)]
  [MinLength(StaticValues.MIN_PHONE_LENGTH)]
  public string? PhoneNumber { get; set; }

  [EmailAddress]
  [MaxLength(StaticValues.MAX_EMAIL_LENGTH)]
  public string ContactEmail { get; set; } = "contact@mail.com";

  [MaxLength(StaticValues.MAX_PHONE_LENGTH)]
  [MinLength(StaticValues.MIN_PHONE_LENGTH)]
  [Phone]
  public string? WhatsApp { get; set; }


  [MaxLength(StaticValues.MAX_DOMAIN_LENGTH)]
  [Url]
  public string? FacebookLink { get; set; }

  [MaxLength(StaticValues.MAX_DOMAIN_LENGTH)]
  [Url]
  public string? InstagramLink { get; set; }

  [MaxLength(StaticValues.MAX_DOMAIN_LENGTH)]
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