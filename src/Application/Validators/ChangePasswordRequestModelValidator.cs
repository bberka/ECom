using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Validators
{
    public class ChangePasswordRequestModelValidator : AbstractValidator<ChangePasswordRequestModel>, IValidator<ChangePasswordRequestModel>
    {
        public ChangePasswordRequestModelValidator()
        {
            RuleFor(x => x.OldPassword)
                .NotEmpty()
                .NotNull()
                .MinimumLength(ConstantMgr.StringMinLength);

            RuleFor(x => x.NewPassword)
                .NotNull()
                .NotEmpty()
                .MinimumLength(ConstantMgr.StringMinLength)
                .MaximumLength(ConstantMgr.PasswordMaxLength);

            RuleFor(x => x.NewPasswordConfirm)
                .NotNull()
                .NotEmpty()
                .MinimumLength(ConstantMgr.StringMinLength)
                .MaximumLength(ConstantMgr.PasswordMaxLength);

            RuleFor(x => x.NewPassword)
                .Equal(x => x.NewPasswordConfirm)
                .OverridePropertyName("'New Password' and 'New Password Confirm'")
                .WithErrorCode(ErrorCode.MustBeSame.ToString());

            RuleFor(x => x.OldPassword)
                .NotEqual(x => x.NewPassword)
                .OverridePropertyName("'Old Password' and 'New Password'")
                .WithErrorCode(ErrorCode.CanNotBeSame.ToString());
        }

    }
}
