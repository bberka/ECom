namespace ECom.Shared.Entities;

[Table("Users", Schema = "ECPrivate")]
public class User : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }


  [MinLength(ValidationSettings.MinHashedPasswordLength)]
  [MaxLength(ValidationSettings.MaxHashedPasswordLength)]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  [IgnoreDataMember]

  public string Password { get; set; }

  [MaxLength(ValidationSettings.MaxEmailLength)]
  [EmailAddress]
  public string EmailAddress { get; set; }


  public bool IsEmailVerified { get; set; }


  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  public string FirstName { get; set; }



  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  public string LastName { get; set; }



  [MinLength(ValidationSettings.MinPhoneLength)]
  [MaxLength(ValidationSettings.MaxPhoneLength)]
  public string PhoneNumber { get; set; }

  public int? CitizenShipNumber { get; set; }
  public int? TaxNumber { get; set; }

  [MaxLength(ValidationSettings.MaxTokenLength)]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  [IgnoreDataMember]
  public string? OAuthKey { get; set; } = null;

  public OAuthType OAuthType { get; set; } = OAuthType.None;

  [MaxLength(ValidationSettings.MaxTokenLength)]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  [IgnoreDataMember]
  public string? TwoFactorKey { get; set; } = null;

  public TwoFactorType TwoFactorType { get; set; }


  [MinLength(ValidationSettings.MinCultureLength)]
  [MaxLength(ValidationSettings.MaxCultureLength)]
  public string Culture { get; set; } = ConstantMgr.DefaultCulture;

  [MaxLength(ValidationSettings.MaxTokenLength)]
  public string? RefreshJwtToken { get; set; } = null;

  //Virtual
  public virtual List<Address> Addresses { get; set; }
  public virtual List<Collection> Collections { get; set; }
  public virtual List<FavoriteProduct> FavoriteProducts { get; set; }
  public virtual List<Order> Orders { get; set; }
  public virtual List<ProductComment> ProductComments { get; set; }
  public virtual List<PasswordResetToken> PasswordResetTokens { get; set; }
  public virtual List<EmailVerifyToken> EmailVerifyTokens { get; set; }


  public static User FromRegisterRequest(RegisterUserRequestDto requestDto) {
    return new User {
      CitizenShipNumber = requestDto.CitizenshipNumber,
      RegisterDate = DateTime.Now,
      DeleteDate = null,
      EmailAddress = requestDto.EmailAddress,
      PhoneNumber = requestDto.PhoneNumber,
      Password = requestDto.Password.ToHashedText(),
      IsEmailVerified = false,
      TaxNumber = requestDto.TaxNumber,
      TwoFactorType = 0,
      Culture = "en",
      FirstName = requestDto.FirstName,
      LastName = requestDto.LastName,
    };
  }
}