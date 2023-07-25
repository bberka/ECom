namespace ECom.Domain.Entities;

[Table("SmtpOptions", Schema = "ECOption")]
public class SmtpOption : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }


  [MaxLength(500)]
  public string Host { get; set; }

  [EmailAddress]
  public string Email { get; set; }

  [MaxLength(500)]
  public string Password { get; set; }


  public bool Ssl { get; set; }


  [Range(0, 65535)]
  public int Port { get; set; }
}