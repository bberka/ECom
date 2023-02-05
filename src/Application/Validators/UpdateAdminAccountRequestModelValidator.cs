using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Validators
{
    public class UpdateAdminAccountRequestModelValidator : AbstractValidator<UpdateAdminAccountRequestModel>, IValidator<UpdateAdminAccountRequestModel>
    {

        public UpdateAdminAccountRequestModelValidator(IValidationDbService validationDbService)
        {
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .NotNull()
                .EmailAddress();
            RuleFor(x => x.EmailAddress)
                .Must(validationDbService.NotUsedEmail_Admin)
                .WithErrorCode(CustomValidationType.AlreadyInUse.ToString());
        }
    }
}
