namespace ECom.Business.Validators;

public class UpdateCollectionRequestValidator : AbstractValidator<Request_Collection_Update>,
                                                IValidator<Request_Collection_Update>
{
  public UpdateCollectionRequestValidator() {
    RuleFor(x => x.CollectionName)
      .MinimumLength(3)
      .MaximumLength(32);
  }
}