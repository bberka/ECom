using ECom.Shared.Abstract.Services;
using ECom.Shared.Extensions;

namespace ECom.Application.Validators;

public class CategoryUpdateRequestValidator : AbstractValidator<CategoryAddOrUpdateRequestDto>
{
  public CategoryUpdateRequestValidator(IValidationService validationService) {
    RuleFor(x => x.Name)
      .ApplyNameRule();
  }
}