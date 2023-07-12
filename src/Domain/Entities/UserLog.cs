namespace ECom.Domain.Entities;

[Table("UserLogs", Schema = "ECLog")]
public class UserLog : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public long Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.Now;

  public int Severity { get; set; }

  [MaxLength(32)]
  public string OperationName { get; set; }

  [MaxLength(64)]
  public string ErrorCode { get; set; } = "None";

  public int Rv { get; set; } = -1;

  [MaxLength(32)]
  public string RemoteIpAddress { get; set; }

  [MaxLength(32)]
  public string? XReal_IpAddress { get; set; }

  [MaxLength(32)]
  public string? CFConnecting_IpAddress { get; set; }

  [MaxLength(512)]
  public string UserAgent { get; set; }


  [MaxLength(2000)]
  public string? ResultErrors { get; set; }

  [MaxLength(2000)]
  public string? Params { get; set; }

  public int? UserId { get; set; }
}