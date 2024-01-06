using ECom.Foundation.Static;

namespace ECom.Business.Validators;

public class ChangePasswordRequestValidator : AbstractValidator<Request_Password_Change>,
                                              IValidator<Request_Password_Change>
{
  public ChangePasswordRequestValidator(IValidationService validationService) {
    RuleFor(x => x.OldPassword)
      .ApplyPasswordRule();

    RuleFor(x => x.NewPassword)
      .ApplyPasswordRule();

    RuleFor(x => x.RepeatNewPassword)
      .ApplyPasswordRule();

    RuleFor(x => x.NewPassword)
      .Equal(x => x.RepeatNewPassword)
      .OverridePropertyName("'New Password' and 'New Password Confirm'")
      .WithErrorCode("MustBeSame");

    RuleFor(x => x.OldPassword)
      .NotEqual(x => x.NewPassword)
      .OverridePropertyName("'Old Password' and 'New Password'")
      .WithErrorCode("CanNotBeSame");


    RuleFor(x => x.NewPassword)
      .Must(validationService.NotHasSpace)
      .WithErrorCode(CustomValidationType.CanNotContainSpace.ToString());

    RuleFor(x => x.NewPassword)
      .Must(validationService.NotHasSpecialChar)
      .WithErrorCode(CustomValidationType.MustContainSpecialCharacter.ToString());

    RuleFor(x => x.NewPassword)
      .Must(validationService.HasNumber)
      .WithErrorCode(CustomValidationType.MustContainDigit.ToString());

    RuleFor(x => x.NewPassword)
      .Must(validationService.HasLowerCase)
      .WithErrorCode(CustomValidationType.MustContainLowerCase.ToString());

    RuleFor(x => x.NewPassword)
      .Must(validationService.HasUpperCase)
      .WithErrorCode(CustomValidationType.MustContainUpperCase.ToString());
  }
}