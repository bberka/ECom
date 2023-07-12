using ECom.Domain.DTOs.CategoryDTOs;

namespace ECom.Application.Validators;

public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>,
  IValidator<UpdateCategoryRequest>
{
  public UpdateCategoryRequestValidator() {
    RuleFor(x => x.Name)
      .MinimumLength(3)
      .MinimumLength(64);

    RuleFor(x => x.Culture)
      .Length(4);

    RuleFor(x => x.CategoryId)
      .GreaterThan(0);
  }
}