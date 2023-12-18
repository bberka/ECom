namespace ECom.Business.Validators;

public class UpdateUserRequestValidator : AbstractValidator<Request_User_Update>,
                                          IValidator<Request_User_Update>
{
  public UpdateUserRequestValidator() {
    RuleFor(x => x.EmailAddress)
      .EmailAddress();

    RuleFor(x => x.PhoneNumber)
      .MinimumLength(10)
      .MaximumLength(13);

    RuleFor(x => x.FirstName)
      .MinimumLength(3)
      .MaximumLength(32);

    RuleFor(x => x.LastName)
      .MinimumLength(3)
      .MaximumLength(32);
  }
}