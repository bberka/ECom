using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("Users", Schema = "ECPrivate")]
public class User : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }


  [MinLength(StaticValues.MIN_HASHED_PASSWORD_LENGTH)]
  [MaxLength(StaticValues.MAX_HASHED_PASSWORD_LENGTH)]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  [IgnoreDataMember]

  public string Password { get; set; }

  [MaxLength(StaticValues.MAX_EMAIL_LENGTH)]
  [EmailAddress]
  public string EmailAddress { get; set; }


  public bool IsEmailVerified { get; set; }


  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string FirstName { get; set; }


  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string LastName { get; set; }


  [MinLength(StaticValues.MIN_PHONE_LENGTH)]
  [MaxLength(StaticValues.MAX_PHONE_LENGTH)]
  public string PhoneNumber { get; set; }

  public int? CitizenShipNumber { get; set; }

  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  [IgnoreDataMember]
  public string? OAuthKey { get; set; } = null;

  public OAuthType OAuthType { get; set; } = OAuthType.None;

  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  [IgnoreDataMember]
  public string? TwoFactorKey { get; set; } = null;

  public TwoFactorType TwoFactorType { get; set; }

  public CultureType Culture { get; set; } = StaticValues.DEFAULT_LANGUAGE;


  //Virtual
  public virtual List<Address> Addresses { get; set; }
  public virtual List<Collection> Collections { get; set; }
  public virtual List<FavoriteProduct> FavoriteProducts { get; set; }
  public virtual List<Order> Orders { get; set; }
  public virtual List<ProductComment> ProductComments { get; set; }
  public virtual List<PasswordResetToken> PasswordResetTokens { get; set; }
  public virtual List<EmailVerifyToken> EmailVerifyTokens { get; set; }
}