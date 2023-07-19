namespace ECom.Application.Validators;

public class CategoryUpdateRequestValidator : AbstractValidator<AddOrUpdateCategoryRequest>
{
  public CategoryUpdateRequestValidator(IValidationService validationService) {
    RuleFor(x => x.Name)
      .MinimumLength(3)
      .MinimumLength(64);
  }
}