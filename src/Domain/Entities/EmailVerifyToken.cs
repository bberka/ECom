namespace ECom.Domain.Entities;

[Table("EmailVerifyTokens", Schema = "ECPrivate")]
public class EmailVerifyToken : IEntity
{
  [Key]
  [MaxLength(512)]
  public string Token { get; set; }

  [MaxLength(ConstantMgr.EmailMaxLength)]
  [EmailAddress]
  public string EmailAddress { get; set; }

  public bool IsUsed { get; set; } = false;

  public DateTime RegisterDate { get; set; } = DateTime.Now;
  public DateTime ExpireDate { get; set; }

  public int UserId { get; set; }


  //virtual
  public virtual User User { get; set; }
}