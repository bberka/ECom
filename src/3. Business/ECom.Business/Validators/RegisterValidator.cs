namespace ECom.Business.Validators;

public class RegisterValidator : AbstractValidator<Request_User_Register>,
                                 IValidator<Request_User_Register>
{
  public RegisterValidator(IValidationService validationService) {
    RuleFor(x => x.Password)
      .MinimumLength(6)
      .MaximumLength(32);


    RuleFor(x => x.EmailAddress)
      .EmailAddress();

    RuleFor(x => x.Password)
      .Must(validationService.NotHasSpace)
      .WithErrorCode(CustomValidationType.CanNotContainSpace.ToString());

    RuleFor(x => x.Password)
      .Must(validationService.NotHasSpecialChar)
      .WithErrorCode(CustomValidationType.MustContainSpecialCharacter.ToString());

    RuleFor(x => x.Password)
      .Must(validationService.HasNumber)
      .WithErrorCode(CustomValidationType.MustContainDigit.ToString());

    RuleFor(x => x.Password)
      .Must(validationService.HasLowerCase)
      .WithErrorCode(CustomValidationType.MustContainLowerCase.ToString());

    RuleFor(x => x.Password)
      .Must(validationService.HasUpperCase)
      .WithErrorCode(CustomValidationType.MustContainUpperCase.ToString());

    RuleFor(x => x.EmailAddress)
      .Must(validationService.NotUsedEmail_User)
      .WithErrorCode(CustomValidationType.AlreadyInUse.ToString());
  }
}