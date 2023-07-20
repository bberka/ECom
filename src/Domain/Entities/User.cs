namespace ECom.Domain.Entities;

[Table("Users", Schema = "ECPrivate")]
public class User : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.Now;

  public bool IsValid { get; set; } = true;


  [MinLength(ConstantMgr.PasswordMinLength)]
  [MaxLength(ConstantMgr.PasswordMaxLength)]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  [IgnoreDataMember]

  public string Password { get; set; }

  [MaxLength(ConstantMgr.EmailMaxLength)]
  [EmailAddress]
  public string EmailAddress { get; set; }


  public bool IsEmailVerified { get; set; }


  [MinLength(ConstantMgr.NameMinLength)]
  [MaxLength(ConstantMgr.NameMaxLength)]
  public string FirstName { get; set; }


  [MinLength(ConstantMgr.NameMinLength)]
  [MaxLength(ConstantMgr.NameMaxLength)]
  public string LastName { get; set; }


  [MinLength(ConstantMgr.PhoneNumberMinLength)]
  [MaxLength(ConstantMgr.PhoneNumberMaxLength)]
  public string PhoneNumber { get; set; }

  public int? CitizenShipNumber { get; set; }
  public int? TaxNumber { get; set; }

  [MaxLength(512)]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  [IgnoreDataMember]
  public string? OAuthKey { get; set; } = null;

  public byte? OAuthType { get; set; } = null;

  [MaxLength(255)]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  [IgnoreDataMember]
  public string? TwoFactorKey { get; set; } = null;

  /// <summary>
  ///   0: None
  ///   1: Email
  ///   2: Phone
  ///   3: Authy
  /// </summary>
  public byte TwoFactorType { get; set; }

  public DateTime? DeletedDate { get; set; }

  [MinLength(2)]
  [MaxLength(4)]
  public string Culture { get; set; } = ConstantMgr.DefaultCulture;


  //Virtual
  public virtual List<Address> Addresses { get; set; }
  public virtual List<Collection> Collections { get; set; }
  public virtual List<FavoriteProduct> FavoriteProducts { get; set; }
  public virtual List<Order> Orders { get; set; }
  public virtual List<ProductComment> ProductComments { get; set; }
  public virtual List<UserLog> UserLogs { get; set; }
  public virtual List<PasswordResetToken> PasswordResetTokens { get; set; }
  public virtual List<EmailVerifyToken> EmailVerifyTokens { get; set; }

  public virtual int FailedLoginCount => UserLogs?
    .Where(x => x.OperationName == "Auth.Login" && x.Rv != -1 && x.Params.Contains(EmailAddress))
    .Count() ?? 0;

  public virtual int TotalLoginCount => UserLogs?
    .Where(x => x.OperationName == "Auth.Login" && x.Rv == 0 && x.Params.Contains(EmailAddress))
    .Count() ?? 0;

  public static User FromRegisterRequest(RegisterUserRequest request) {
    return new User {
      CitizenShipNumber = request.CitizenshipNumber,
      RegisterDate = DateTime.Now,
      DeletedDate = null,
      EmailAddress = request.EmailAddress,
      PhoneNumber = request.PhoneNumber,
      Password = request.Password.ToEncryptedText(),
      IsEmailVerified = false,
      IsValid = true,
      TaxNumber = request.TaxNumber,
      TwoFactorType = 0,
      Culture = "en",
      FirstName = request.FirstName,
      LastName = request.LastName
    };
  }
}