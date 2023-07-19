namespace ECom.Application.CustomValidators;

public static class CustomValidatorExtensions
{
  public static IRuleBuilderOptions<T, int> IsValidId<T, TElement>(this IRuleBuilder<T, int> ruleBuilder) {
    return ruleBuilder.SetValidator(new IdValidator<T>());
  }
}