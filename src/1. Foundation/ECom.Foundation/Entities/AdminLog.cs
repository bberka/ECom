using ECom.Foundation.Enum;

namespace ECom.Foundation.Entities;

[Table("AdminLogs", Schema = "ECLog")]
public class AdminLog : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public ResultLevel Level { get; set; }


  [MaxLength(ConstantContainer.MaxErrorCodeLength)]
  public string ErrorCode { get; set; } = "None";

  public string? RequestData { get; set; }
  public Guid? AdminId { get; set; }

  public int HttpStatusCode { get; set; } = 0;

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

  public AdminActionType ActionType { get; set; }
}