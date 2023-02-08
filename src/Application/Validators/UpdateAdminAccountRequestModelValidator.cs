using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Validators
{
    public class UpdateAdminAccountRequestModelValidator : AbstractValidator<UpdateAdminAccountRequestModel>, IValidator<UpdateAdminAccountRequestModel>
    {

        public UpdateAdminAccountRequestModelValidator(IValidationService validationService)
        {
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .NotNull()
                .EmailAddress();
            RuleFor(x => x.EmailAddress)
                .Must(validationService.NotUsedEmail_Admin)
                .WithErrorCode(CustomValidationType.AlreadyInUse.ToString());
        }
    }
}
