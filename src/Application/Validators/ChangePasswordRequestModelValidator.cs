using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Validators
{
    public class ChangePasswordRequestModelValidator : AbstractValidator<ChangePasswordRequestModel>, IValidator<ChangePasswordRequestModel>
    {

        public ChangePasswordRequestModelValidator(IValidationService validationService)
        {
            RuleFor(x => x.OldPassword)
                .MinimumLength(6);

            RuleFor(x => x.NewPassword)
                .MinimumLength(6)
                .MaximumLength(32);

            RuleFor(x => x.NewPasswordConfirm)
                .MinimumLength(6)
                .MaximumLength(32);

            RuleFor(x => x.NewPassword)
                .Equal(x => x.NewPasswordConfirm)
                .OverridePropertyName("'New Password' and 'New Password Confirm'")
                .WithErrorCode(ErrorCode.MustBeSame.ToString());

            RuleFor(x => x.OldPassword)
                .NotEqual(x => x.NewPassword)
                .OverridePropertyName("'Old Password' and 'New Password'")
                .WithErrorCode(ErrorCode.CanNotBeSame.ToString());


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
}
