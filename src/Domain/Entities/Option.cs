using EasMe.EntityFrameworkCore;

namespace ECom.Domain.Entities;

[Table("Options", Schema = "ECOption")]
public class Option : IEntity
{
  [Key]
  public bool Key { get; set; } = true;
  public bool IsOpen { get; set; } = true;
  public bool RequireUpperCaseInPassword { get; set; } = false;
  public bool RequireLowerCaseInPassword { get; set; } = false;
  public bool RequireSpecialCharacterInPassword { get; set; } = false;
  public bool RequireNumberInPassword { get; set; } = false;

  [Range(15, 43200)]
  public int EmailVerificationTimeoutMinutes { get; set; } = 30;

  [Range(15, 43200)]
  public int PasswordResetTimeoutMinutes { get; set; } = 30;
  
  public Currency DefaultCurrency { get; set; } = Currency.Lira;

  public bool ShowStock { get; set; } = false;
  public byte PagingProductCount { get; set; } = 20;
  public byte ProductImageLimit { get; set; } = 10;
  public byte ProductCommentImageLimit { get; set; } = 5;
}