

namespace ECom.Domain.Entities;

[Table("SecurityLogs", Schema = "ECLog")]
public class SecurityLog : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;

  [MaxLength(ValidationSettings.MaxReasonLength)]
  public string Reason { get; set; }

  public short HttpStatusCode { get; set; } = 0;

  [MaxLength(32)]
  public string RemoteIpAddress { get; set; }

  [MaxLength(32)]
  public string? XReal_IpAddress { get; set; } = null;

  [MaxLength(32)]
  public string? CFConnecting_IpAddress { get; set; } = null;

  [MaxLength(512)]
  public string UserAgent { get; set; }

  [MaxLength(2000)]
  public string RequestUrl { get; set; }
  [MaxLength(2000)]
  public string? QueryString { get; set; }
}