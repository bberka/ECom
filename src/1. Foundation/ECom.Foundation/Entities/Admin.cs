using ECom.Foundation.Enum;

namespace ECom.Foundation.Entities;

[Table("Admins", Schema = "ECOperation")]
public class Admin : IEntity
{
  public const string LocKey = "admin";

  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  [MinLength(ConstantContainer.MinHashedPasswordLength)]
  [MaxLength(ConstantContainer.MaxHashedPasswordLength)]
  public string Password { get; set; }

  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string FirstName { get; set; }


  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string LastName { get; set; }

  [EmailAddress]
  [MaxLength(ConstantContainer.MaxEmailLength)]
  public string EmailAddress { get; set; }


  [MaxLength(255)]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  [IgnoreDataMember]
  public string? TwoFactorKey { get; set; }

  public TwoFactorType TwoFactorType { get; set; }

  public bool IsDeleted => DeleteDate.HasValue;

  public string RoleId { get; set; }

  //virtual
  public Role Role { get; set; } = null!;
  public virtual List<AdminLog> AdminLogs { get; set; }

  public LanguageType Culture { get; set; } = ConstantContainer.DefaultLanguage;

  [MinLength(ConstantContainer.MinPhoneLength)]
  [MaxLength(ConstantContainer.MaxPhoneLength)]
  public string PhoneNumber { get; set; }
}