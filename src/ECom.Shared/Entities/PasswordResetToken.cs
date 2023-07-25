namespace ECom.Shared.Entities;

[Table("PasswordResetTokens", Schema = "ECPrivate")]
[Index(nameof(Token))]
public class PasswordResetToken : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime ExpireDate { get; set; }
  public DateTime? UseDate { get; set; }

  [MaxLength(ValidationSettings.MaxTokenLength)]
  [MinLength(ValidationSettings.MinTokenLength)]
  public string Token { get; set; }

  [EmailAddress]
  [MaxLength(ValidationSettings.MaxEmailLength)]
  public string EmailAddress { get; set; }
  

  public Guid UserId { get; set; }

  //virtual
  public virtual User User { get; set; }
}