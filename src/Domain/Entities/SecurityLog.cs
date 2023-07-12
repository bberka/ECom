namespace ECom.Domain.Entities;

[Table("SecurityLogs", Schema = "ECLog")]
public class SecurityLog : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public long Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.Now;

  public int HttpStatusCodeResponse { get; set; }

  [MaxLength(2000)]
  public string RequestUrl { get; set; }


  [MaxLength(2000)]
  public string QueryString { get; set; }

  [MaxLength(64)]
  public string RemoteIpAddress { get; set; }

  [MaxLength(64)]
  public string? XReal_IpAddress { get; set; }

  [MaxLength(64)]
  public string? CFConnecting_IpAddress { get; set; }

  [MaxLength(512)]
  public string? UserAgent { get; set; }

  [MaxLength(2000)]
  public string? Params { get; set; }
}