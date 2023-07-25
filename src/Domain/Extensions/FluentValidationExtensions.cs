using FluentValidation.Validators;
using FluentValidation;

namespace ECom.Domain.Extensions;

public static class FluentValidationExtensions
{
  public static IRuleBuilderOptions<T, string> ApplyNameRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .NotEmpty()
      .MinimumLength(ValidationSettings.MinNameLength)
      .MaximumLength(ValidationSettings.MaxNameLength);
  }
  public static IRuleBuilderOptions<T, string> ApplyAddressRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .NotEmpty()
      .MinimumLength(ValidationSettings.MinAddressLength)
      .MaximumLength(ValidationSettings.MaxAddressLength);
  }
  public static IRuleBuilderOptions<T, string> ApplyTokenRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .NotEmpty()
      .MinimumLength(ValidationSettings.MinTokenLength)
      .MaximumLength(ValidationSettings.MaxTokenLength);
  }
  public static IRuleBuilderOptions<T, string> ApplyPasswordRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .NotEmpty()
      .MinimumLength(ValidationSettings.MinPasswordLength)
      .MaximumLength(ValidationSettings.MaxPasswordLength);
  }
  public static IRuleBuilderOptions<T, string> ApplyHashedPasswordRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .NotEmpty()
      .MinimumLength(ValidationSettings.MinHashedPasswordLength)
      .MaximumLength(ValidationSettings.MaxHashedPasswordLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyPhoneRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .NotEmpty()
      .MinimumLength(ValidationSettings.MinPhoneLength)
      .MaximumLength(ValidationSettings.MaxPhoneLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyCityRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .NotEmpty()
      .MinimumLength(ValidationSettings.MinCityLength)
      .MaximumLength(ValidationSettings.MaxCityLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyCountryRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .NotEmpty()
      .MinimumLength(ValidationSettings.MinCountryLength)
      .MaximumLength(ValidationSettings.MaxCountryLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyPostalCodeRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .NotEmpty()
      .MinimumLength(ValidationSettings.MinPostalCodeLength)
      .MaximumLength(ValidationSettings.MaxPostalCodeLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyDescriptionRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .NotEmpty()
      .MinimumLength(ValidationSettings.MinDescriptionLength)
      .MaximumLength(ValidationSettings.MaxDescriptionLength);
  }

  public static IRuleBuilderOptions<T, string>
    ApplyProductDescriptionRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .NotEmpty()
      .MinimumLength(ValidationSettings.MinProductDescriptionLength)
      .MaximumLength(ValidationSettings.MaxProductDescriptionLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyTitleRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .NotEmpty()
      .MinimumLength(ValidationSettings.MinTitleLength)
      .MaximumLength(ValidationSettings.MaxTitleLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyMessageRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .NotEmpty()
      .MinimumLength(ValidationSettings.MinMessageLength)
      .MaximumLength(ValidationSettings.MaxMessageLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyEmailRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .NotEmpty()
      .EmailAddress();
  }
  public static IRuleBuilderOptions<T, string> ApplyMemoRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .MaximumLength(ValidationSettings.MaxMemoLength);
  }


  public static IRuleBuilderOptions<T, string> ApplyProductCommentRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .NotEmpty()
      .MinimumLength(ValidationSettings.MinProductCommentLength)
      .MaximumLength(ValidationSettings.MaxProductCommentLength);
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