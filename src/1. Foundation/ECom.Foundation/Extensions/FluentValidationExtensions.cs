using FluentValidation;

namespace ECom.Foundation.Extensions;

public static class FluentValidationExtensions
{
  public static IRuleBuilderOptions<T, string> ApplyNameRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(ConstantContainer.MinNameLength)
           .MaximumLength(ConstantContainer.MaxNameLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyAddressRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(ConstantContainer.MinAddressLength)
           .MaximumLength(ConstantContainer.MaxAddressLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyTokenRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(ConstantContainer.MinTokenLength)
           .MaximumLength(ConstantContainer.MaxTokenLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyPasswordRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(ConstantContainer.MinPasswordLength)
           .MaximumLength(ConstantContainer.MaxPasswordLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyHashedPasswordRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(ConstantContainer.MinHashedPasswordLength)
           .MaximumLength(ConstantContainer.MaxHashedPasswordLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyPhoneRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(ConstantContainer.MinPhoneLength)
           .MaximumLength(ConstantContainer.MaxPhoneLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyCityRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(ConstantContainer.MinCityLength)
           .MaximumLength(ConstantContainer.MaxCityLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyCountryRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(ConstantContainer.MinCountryLength)
           .MaximumLength(ConstantContainer.MaxCountryLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyPostalCodeRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(ConstantContainer.MinPostalCodeLength)
           .MaximumLength(ConstantContainer.MaxPostalCodeLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyDescriptionRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(ConstantContainer.MinDescriptionLength)
           .MaximumLength(ConstantContainer.MaxDescriptionLength);
  }

  public static IRuleBuilderOptions<T, string>
    ApplyProductDescriptionRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(ConstantContainer.MinProductDescriptionLength)
           .MaximumLength(ConstantContainer.MaxProductDescriptionLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyTitleRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(ConstantContainer.MinTitleLength)
           .MaximumLength(ConstantContainer.MaxTitleLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyMessageRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(ConstantContainer.MinMessageLength)
           .MaximumLength(ConstantContainer.MaxMessageLength);
  }

  public static IRuleBuilderOptions<T, string> ApplyEmailRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .EmailAddress();
  }

  public static IRuleBuilderOptions<T, string> ApplyMemoRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
      .MaximumLength(ConstantContainer.MaxMemoLength);
  }


  public static IRuleBuilderOptions<T, string> ApplyProductCommentRule<T>(this IRuleBuilder<T, string> ruleBuilder) {
    return ruleBuilder
           .NotEmpty()
           .MinimumLength(ConstantContainer.MinProductCommentLength)
           .MaximumLength(ConstantContainer.MaxProductCommentLength);
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