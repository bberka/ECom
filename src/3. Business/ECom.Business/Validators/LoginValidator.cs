namespace ECom.Business.Validators;

public class LoginValidator : AbstractValidator<Request_Login>,
                              IValidator<Request_Login>
{
  public LoginValidator() {
    RuleFor(x => x.EmailAddress)
      .EmailAddress();

    RuleFor(x => x.Password)
      .MinimumLength(6)
      .MaximumLength(32);
  }
}