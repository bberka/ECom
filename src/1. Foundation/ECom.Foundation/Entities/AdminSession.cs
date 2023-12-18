using ECom.Foundation.Enum;

namespace ECom.Foundation.Entities;

[Table("AdminSessions", Schema = "ECSession")]
public sealed class AdminSession : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public Guid AdminId { get; set; }
  public bool IsValid { get; set; } = true;
  public DateTime RegisterDate { get; set; } = DateTime.Now;
  public DateTime ExpireDate { get; set; }
  public string AccessToken { get; set; }

  [MaxLength(ConstantContainer.MaxTokenLength)]
  public string RefreshToken { get; set; }

  public SessionCreateType SessionCreateType { get; set; }
  public Admin Admin { get; set; }

  public Guid? OldSessionId { get; set; }
}