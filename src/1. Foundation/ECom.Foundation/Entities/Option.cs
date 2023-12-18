using ECom.Foundation.Enum;

namespace ECom.Foundation.Entities;

[Table("Options", Schema = "ECOption")]
public class Option : IEntity,
                      ICloneable
{
  public const string LocKey = "option";

  [Key]
  public bool Key { get; set; } = true;

  public DateTime? UpdateDate { get; set; }


  public bool IsOpen { get; set; } = true;

  public bool RequireUpperCaseInPassword { get; set; } = false;

  public bool RequireLowerCaseInPassword { get; set; } = false;

  public bool RequireSpecialCharacterInPassword { get; set; } = false;

  public bool RequireNumberInPassword { get; set; } = false;

  [Range(ConstantContainer.MinTokenExpireLimit, ConstantContainer.MaxTokenExpireLimit)]
  public int EmailVerificationTimeoutMinutes { get; set; } = 30;

  [Range(ConstantContainer.MinTokenExpireLimit, ConstantContainer.MaxTokenExpireLimit)]
  public int PasswordResetTimeoutMinutes { get; set; } = 30;

  public CurrencyType DefaultCurrencyType { get; set; } = CurrencyType.Lira;

  public bool ShowStock { get; set; } = false;


  public bool ShowCurrencyConversionRate { get; set; } = false;

  [Range(ConstantContainer.MinPageElementCountLimit, ConstantContainer.MaxPageElementCountLimit)]
  public byte PagingProductCount { get; set; } = 20;

  [Range(ConstantContainer.MinImageCountLimit, ConstantContainer.MaxImageCountLimit)]
  public byte ProductImageLimit { get; set; } = 10;

  [Range(ConstantContainer.MinImageCountLimit, ConstantContainer.MaxImageCountLimit)]
  public byte ProductCommentImageLimit { get; set; } = 5;

  public object Clone() {
    return MemberwiseClone();
  }

  public Option CloneCast() {
    return (Option)MemberwiseClone();
  }
}