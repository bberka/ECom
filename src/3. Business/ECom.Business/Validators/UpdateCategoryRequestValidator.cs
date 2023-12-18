namespace ECom.Business.Validators;

public class UpdateCategoryRequestValidator : AbstractValidator<Request_Category_Update>,
                                              IValidator<Request_Category_Update>
{
  public UpdateCategoryRequestValidator() {
    RuleFor(x => x.NameKey)
      .MinimumLength(3)
      .MinimumLength(64);

    RuleFor(x => x.NameKey)
      .Length(2);
  }
}