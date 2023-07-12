namespace ECom.Domain.Entities;

[Table("PasswordResetTokens", Schema = "ECPrivate")]
public class PasswordResetToken : IEntity
{
  [Key]
  [MaxLength(512)]
  public string Token { get; set; }

  public bool IsUsed { get; set; }
  public DateTime RegisterDate { get; set; }
  public DateTime ExpireDate { get; set; }
  public int UserId { get; set; }

  //Virtual
  public virtual User User { get; set; }
}