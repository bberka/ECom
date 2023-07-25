using ECom.Domain.Abstract.Services;
using ECom.Shared.Constants;

namespace ECom.Application.Validators;

public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>,
  IValidator<ChangePasswordRequest>
{
  public ChangePasswordRequestValidator(IValidationService validationService) {
    RuleFor(x => x.OldPassword)
      .ApplyPasswordRule();

    RuleFor(x => x.NewPassword)
      .ApplyPasswordRule();

    RuleFor(x => x.NewPasswordConfirm)
      .ApplyPasswordRule();

    RuleFor(x => x.NewPassword)
      .Equal(x => x.NewPasswordConfirm)
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