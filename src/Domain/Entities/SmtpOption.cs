namespace ECom.Domain.Entities;

public class SmtpOption : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }


  public bool IsValid { get; set; } = true;


  [MaxLength(255)]
  public string Host { get; set; }


  [MaxLength(ConstantMgr.EmailMaxLength)]
  [EmailAddress]
  public string Email { get; set; }

  [MaxLength(255)]
  public string Password { get; set; }


  public bool Ssl { get; set; }


  [Range(0, 65535)]
  public int Port { get; set; }
}