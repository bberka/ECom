using ECom.Shared.Abstract.Services;
using ECom.Shared.Extensions;

namespace ECom.Application.Validators;

public class CategoryUpdateRequestValidator : AbstractValidator<AddOrUpdateCategoryRequest>
{
  public CategoryUpdateRequestValidator(IValidationService validationService) {
    RuleFor(x => x.Name)
      .ApplyNameRule();
  }
}