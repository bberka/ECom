using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("Admins", Schema = "ECOperation")]
public class Admin : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  [MinLength(StaticValues.MIN_HASHED_PASSWORD_LENGTH)]
  [MaxLength(StaticValues.MAX_HASHED_PASSWORD_LENGTH)]
  public string Password { get; set; }

  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string FirstName { get; set; }


  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string LastName { get; set; }

  [EmailAddress]
  [MaxLength(StaticValues.MAX_EMAIL_LENGTH)]
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

  public CultureType Culture { get; set; } = StaticValues.DEFAULT_LANGUAGE;

  [MinLength(StaticValues.MIN_PHONE_LENGTH)]
  [MaxLength(StaticValues.MAX_PHONE_LENGTH)]
  public string PhoneNumber { get; set; }
}