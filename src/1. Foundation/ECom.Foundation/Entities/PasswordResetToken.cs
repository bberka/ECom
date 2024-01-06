using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("PasswordResetTokens", Schema = "ECPrivate")]
[Index(nameof(Token))]
public class PasswordResetToken : IEntity
{
  [Key]
  public Guid Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime ExpireDate { get; set; }
  public DateTime? UseDate { get; set; }

  [MaxLength(StaticValues.MAX_TOKEN_LENGTH)]
  [MinLength(StaticValues.MIN_TOKEN_LENGTH)]
  public string Token { get; set; }

  [EmailAddress]
  [MaxLength(StaticValues.MAX_EMAIL_LENGTH)]
  public string EmailAddress { get; set; }


  public Guid UserId { get; set; }

  //virtual
  public virtual User User { get; set; }
}