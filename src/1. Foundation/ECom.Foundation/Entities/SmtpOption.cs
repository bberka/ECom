using ECom.Foundation.Enum;

namespace ECom.Foundation.Entities;

[Table("SmtpOptions", Schema = "ECOption")]
[Index(nameof(SmtpHostType))]
public class SmtpOption : IEntity
{
  public const string LocKey = "smtp_option";

  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.Now;

  public DateTime? UpdateDate { get; set; }


  [MaxLength(ConstantContainer.MaxDomainLength)]
  [Required]
  public string Host { get; set; }

  [EmailAddress]
  [MaxLength(ConstantContainer.MaxEmailLength)]
  [Required]
  public string EmailAddress { get; set; }

  [MaxLength(ConstantContainer.MaxHashedPasswordLength)]
  [Required]
  public string Password { get; set; }

  [Required]
  public SmtpHostType SmtpHostType { get; set; }

  [Required]
  public bool UseSsl { get; set; }

  [Required]
  [Range(ConstantContainer.MinPortValue, ConstantContainer.MaxPortValue)]
  public int Port { get; set; }
}