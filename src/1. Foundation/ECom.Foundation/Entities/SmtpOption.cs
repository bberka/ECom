using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("SmtpOptions", Schema = "ECOption")]
[Index(nameof(SmtpHostType))]
public class SmtpOption : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.Now;

  public DateTime? UpdateDate { get; set; }


  [MaxLength(StaticValues.MAX_DOMAIN_LENGTH)]
  [Required]
  public string Host { get; set; }

  [EmailAddress]
  [MaxLength(StaticValues.MAX_EMAIL_LENGTH)]
  [Required]
  public string EmailAddress { get; set; }

  [MaxLength(StaticValues.MAX_HASHED_PASSWORD_LENGTH)]
  [Required]
  public string Password { get; set; }

  [Required]
  public SmtpHostType SmtpHostType { get; set; }

  [Required]
  public bool UseSsl { get; set; }

  [Required]
  [Range(StaticValues.MIN_PORT_VALUE, StaticValues.MAX_PORT_VALUE)]
  public int Port { get; set; }
}