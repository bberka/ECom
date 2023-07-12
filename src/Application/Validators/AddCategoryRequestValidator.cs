using ECom.Domain.DTOs.CategoryDTOs;

namespace ECom.Application.Validators;

public class CategoryUpdateRequestValidator : AbstractValidator<UpdateCategoryRequest>,
  IValidator<UpdateCategoryRequest>
{
  public CategoryUpdateRequestValidator(IValidationService validationService) {
    RuleFor(x => x.Name)
      .MinimumLength(3)
      .MinimumLength(64);

    RuleFor(x => x.Culture)
      .Length(4);
  }
}