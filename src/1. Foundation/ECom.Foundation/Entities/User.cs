using ECom.Foundation.Enum;

namespace ECom.Foundation.Entities;

[Table("Users", Schema = "ECPrivate")]
public class User : IEntity
{
  public const string LocKey = "user";

  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }


  [MinLength(ConstantContainer.MinHashedPasswordLength)]
  [MaxLength(ConstantContainer.MaxHashedPasswordLength)]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  [IgnoreDataMember]

  public string Password { get; set; }

  [MaxLength(ConstantContainer.MaxEmailLength)]
  [EmailAddress]
  public string EmailAddress { get; set; }


  public bool IsEmailVerified { get; set; }


  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string FirstName { get; set; }


  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string LastName { get; set; }


  [MinLength(ConstantContainer.MinPhoneLength)]
  [MaxLength(ConstantContainer.MaxPhoneLength)]
  public string PhoneNumber { get; set; }

  public int? CitizenShipNumber { get; set; }

  [MaxLength(ConstantContainer.MaxTokenLength)]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  [IgnoreDataMember]
  public string? OAuthKey { get; set; } = null;

  public OAuthType OAuthType { get; set; } = OAuthType.None;

  [MaxLength(ConstantContainer.MaxTokenLength)]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  [IgnoreDataMember]
  public string? TwoFactorKey { get; set; } = null;

  public TwoFactorType TwoFactorType { get; set; }

  public LanguageType Culture { get; set; } = ConstantContainer.DefaultLanguage;


  //Virtual
  public virtual List<Address> Addresses { get; set; }
  public virtual List<Collection> Collections { get; set; }
  public virtual List<FavoriteProduct> FavoriteProducts { get; set; }
  public virtual List<Order> Orders { get; set; }
  public virtual List<ProductComment> ProductComments { get; set; }
  public virtual List<PasswordResetToken> PasswordResetTokens { get; set; }
  public virtual List<EmailVerifyToken> EmailVerifyTokens { get; set; }
}