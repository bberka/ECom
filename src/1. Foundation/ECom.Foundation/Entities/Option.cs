using ECom.Foundation.Static;

namespace ECom.Foundation.Entities;

[Table("Options", Schema = "ECOption")]
public class Option : IEntity,
                      ICloneable
{
  [Key]
  public bool Key { get; set; } = true;

  public DateTime? UpdateDate { get; set; }


  public bool IsOpen { get; set; } = true;

  public bool RequireUpperCaseInPassword { get; set; } = false;

  public bool RequireLowerCaseInPassword { get; set; } = false;

  public bool RequireSpecialCharacterInPassword { get; set; } = false;

  public bool RequireNumberInPassword { get; set; } = false;

  [Range(StaticValues.MIN_TOKEN_EXPIRE_LIMIT, StaticValues.MAX_TOKEN_EXPIRE_LIMIT)]
  public int EmailVerificationTimeoutMinutes { get; set; } = 30;

  [Range(StaticValues.MIN_TOKEN_EXPIRE_LIMIT, StaticValues.MAX_TOKEN_EXPIRE_LIMIT)]
  public int PasswordResetTimeoutMinutes { get; set; } = 30;

  public CurrencyType DefaultCurrencyType { get; set; } = CurrencyType.TRY;

  public bool ShowStock { get; set; } = false;


  public bool ShowCurrencyConversionRate { get; set; } = false;

  [Range(StaticValues.MIN_PAGE_ELEMENT_COUNT_LIMIT, StaticValues.MAX_PAGE_ELEMENT_COUNT_LIMIT)]
  public byte PagingProductCount { get; set; } = 20;

  [Range(StaticValues.MIN_IMAGE_COUNT_LIMIT, StaticValues.MAX_IMAGE_COUNT_LIMIT)]
  public byte ProductImageLimit { get; set; } = 10;

  [Range(StaticValues.MIN_IMAGE_COUNT_LIMIT, StaticValues.MAX_IMAGE_COUNT_LIMIT)]
  public byte ProductCommentImageLimit { get; set; } = 5;

  public object Clone() {
    return MemberwiseClone();
  }

  public Option CloneCast() {
    return (Option)MemberwiseClone();
  }
}