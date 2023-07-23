



namespace ECom.Domain.Entities;

[Table("AdminLogs", Schema = "ECLog")]
public class AdminLog : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  public CustomResultLevel Level { get; set; }

  [MaxLength(ValidationSettings.MaxOperationLength)]
  public string OperationName { get; set; }

  [MaxLength(ValidationSettings.MaxErrorCodeLength)]
  public string ErrorCode { get; set; } = "None";

  public string? Params { get; set; }
  public Guid? AdminId { get; set; }

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