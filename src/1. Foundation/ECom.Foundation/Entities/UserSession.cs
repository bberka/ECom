using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("UserSessions", Schema = "ECSession")]
public sealed class UserSession : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public Guid UserId { get; set; }
  public bool IsValid { get; set; } = true;
  public DateTime RegisterDate { get; set; } = DateTime.Now;
  public DateTime? UpdateDate { get; set; }
  public DateTime ExpireDate { get; set; }

  public string AccessToken { get; set; }

  public SessionCreateType SessionCreateType { get; set; }

  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]
  public string RefreshToken { get; set; }

  public User User { get; set; }

  public Guid? OldSessionId { get; set; }
}