namespace ECom.Business.Validators;

public class CategoryUpdateRequestValidator : AbstractValidator<Request_Category_Update>
{
  public CategoryUpdateRequestValidator(IValidationService validationService) {
    RuleFor(x => x.NameKey)
      .ApplyNameRule();
  }
}