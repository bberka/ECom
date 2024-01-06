using ECom.Foundation.Static;
using FluentValidation;

namespace ECom.Foundation.Extensions;

public static class FluentValidationExtensions
{
  public static IRuleBuilderOptions<T, string> ApplyNameRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(StaticValues.MIN_NAME_LENGTH)
           .MaximumLength(StaticValues.MAX_NAME_LENGTH);
  }

  public static IRuleBuilderOptions<T, string> ApplyAddressRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(StaticValues.MIN_ADDRESS_LENGTH)
           .MaximumLength(StaticValues.MAX_ADDRESS_LENGTH);
  }

  public static IRuleBuilderOptions<T, string> ApplyTokenRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(StaticValues.MIN_TOKEN_LENGTH)
           .MaximumLength(StaticValues.MAX_TOKEN_LENGTH);
  }

  public static IRuleBuilderOptions<T, string> ApplyPasswordRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(StaticValues.MIN_PASSWORD_LENGTH)
           .MaximumLength(StaticValues.MAX_PASSWORD_LENGTH);
  }

  public static IRuleBuilderOptions<T, string> ApplyHashedPasswordRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(StaticValues.MIN_HASHED_PASSWORD_LENGTH)
           .MaximumLength(StaticValues.MAX_HASHED_PASSWORD_LENGTH);
  }

  public static IRuleBuilderOptions<T, string> ApplyPhoneRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(StaticValues.MIN_PHONE_LENGTH)
           .MaximumLength(StaticValues.MAX_PHONE_LENGTH);
  }

  public static IRuleBuilderOptions<T, string> ApplyCityRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(StaticValues.MIN_CITY_LENGTH)
           .MaximumLength(StaticValues.MAX_CITY_LENGTH);
  }

  public static IRuleBuilderOptions<T, string> ApplyCountryRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(StaticValues.MIN_COUNTRY_LENGTH)
           .MaximumLength(StaticValues.MAX_COUNTRY_LENGTH);
  }

  public static IRuleBuilderOptions<T, string> ApplyPostalCodeRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(StaticValues.MIN_POSTAL_CODE_LENGTH)
           .MaximumLength(StaticValues.MAX_POSTAL_CODE_LENGTH);
  }

  public static IRuleBuilderOptions<T, string> ApplyDescriptionRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(StaticValues.MIN_DESCRIPTION_LENGTH)
           .MaximumLength(StaticValues.MAX_DESCRIPTION_LENGTH);
  }

  public static IRuleBuilderOptions<T, string>
    ApplyProductDescriptionRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(StaticValues.MIN_PRODUCT_DESCRIPTION_LENGTH)
           .MaximumLength(StaticValues.MAX_PRODUCT_DESCRIPTION_LENGTH);
  }

  public static IRuleBuilderOptions<T, string> ApplyTitleRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(StaticValues.MIN_TITLE_LENGTH)
           .MaximumLength(StaticValues.MAX_TITLE_LENGTH);
  }

  public static IRuleBuilderOptions<T, string> ApplyMessageRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(StaticValues.MIN_MESSAGE_LENGTH)
           .MaximumLength(StaticValues.MAX_MESSAGE_LENGTH);
  }

  public static IRuleBuilderOptions<T, string> ApplyEmailRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .EmailAddress();
  }

  public static IRuleBuilderOptions<T, string> ApplyMemoRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .MaximumLength(StaticValues.MAX_MEMO_LENGTH);
  }


  public static IRuleBuilderOptions<T, string> ApplyProductCommentRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(StaticValues.MIN_PRODUCT_COMMENT_LENGTH)
           .MaximumLength(StaticValues.MAX_PRODUCT_COMMENT_LENGTH);
  }

  public static IRuleBuilderOptions<T, decimal> ApplyMoneyRule<T>(this IRuleBuilder<T, decimal> ruleBuilder) {
    return ruleBuilder
      .GreaterThanOrEqualTo(0);
  }

  public static IRuleBuilderOptions<T, int> ApplyMoneyRule<T>(this IRuleBuilder<T, int> ruleBuilder) {
    return ruleBuilder
      .GreaterThanOrEqualTo(0);
  }

  public static IRuleBuilderOptions<T, long> ApplyMoneyRule<T>(this IRuleBuilder<T, long> ruleBuilder) {
    return ruleBuilder
      .GreaterThanOrEqualTo(0);
  }

  public static IRuleBuilderOptions<T, float> ApplyMoneyRule<T>(this IRuleBuilder<T, float> ruleBuilder) {
    return ruleBuilder
      .GreaterThanOrEqualTo(0);
  }

  public static IRuleBuilderOptions<T, long> ApplyCountRule<T>(this IRuleBuilder<T, long> ruleBuilder) {
    return ruleBuilder
      .GreaterThanOrEqualTo(0);
  }

  public static IRuleBuilderOptions<T, int> ApplyCountRule<T>(this IRuleBuilder<T, int> ruleBuilder) {
    return ruleBuilder
      .GreaterThanOrEqualTo(0);
  }

  public static IRuleBuilderOptions<T, double> ApplyCountRule<T>(this IRuleBuilder<T, double> ruleBuilder) {
    return ruleBuilder
      .GreaterThanOrEqualTo(0);
  }
}