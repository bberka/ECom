namespace ECom.Application.Validators;

public class UpdateCategoryRequestValidator : AbstractValidator<CategoryAddOrUpdateRequestDto>,
  IValidator<CategoryAddOrUpdateRequestDto>
{
  public UpdateCategoryRequestValidator() {
    RuleFor(x => x.Name)
      .MinimumLength(3)
      .MinimumLength(64);

    RuleFor(x => x.Name)
      .Length(2);
  }
}