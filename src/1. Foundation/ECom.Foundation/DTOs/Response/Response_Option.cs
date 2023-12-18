using ECom.Foundation.Enum;

namespace ECom.Foundation.DTOs.Response;

public class Response_Option
{
  public bool IsOpen { get; set; } = true;

  public bool RequireUpperCaseInPassword { get; set; } = false;

  public bool RequireLowerCaseInPassword { get; set; } = false;

  public bool RequireSpecialCharacterInPassword { get; set; } = false;

  public bool RequireNumberInPassword { get; set; } = false;

  public int EmailVerificationTimeoutMinutes { get; set; } = 30;

  public int PasswordResetTimeoutMinutes { get; set; } = 30;

  public CurrencyType DefaultCurrencyType { get; set; } = CurrencyType.Lira;

  public bool ShowStock { get; set; } = false;

  public bool ShowCurrencyConversionRate { get; set; } = false;

  public byte PagingProductCount { get; set; } = 20;

  public byte ProductImageLimit { get; set; } = 10;

  public byte ProductCommentImageLimit { get; set; } = 5;
}