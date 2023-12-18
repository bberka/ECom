using ECom.Foundation.DTOs.Response;
using ECom.Foundation.Entities;

namespace ECom.Foundation.Mappers;

public static class OptionMapper
{
  public static Response_Option ToResponse(this Option option) {
    return new Response_Option {
      DefaultCurrencyType = option.DefaultCurrencyType,
      EmailVerificationTimeoutMinutes = option.EmailVerificationTimeoutMinutes,
      IsOpen = option.IsOpen,
      ShowStock = option.ShowStock,
      ShowCurrencyConversionRate = option.ShowCurrencyConversionRate,
      PagingProductCount = option.PagingProductCount,
      PasswordResetTimeoutMinutes = option.PasswordResetTimeoutMinutes,
      ProductCommentImageLimit = option.ProductCommentImageLimit,
      ProductImageLimit = option.ProductImageLimit,
      RequireLowerCaseInPassword = option.RequireLowerCaseInPassword,
      RequireNumberInPassword = option.RequireNumberInPassword,
      RequireSpecialCharacterInPassword = option.RequireSpecialCharacterInPassword,
      RequireUpperCaseInPassword = option.RequireUpperCaseInPassword
    };
  }
}