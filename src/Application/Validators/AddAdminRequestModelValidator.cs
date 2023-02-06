using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Validators
{
    public class AddAdminRequestModelValidator : AbstractValidator<AddAdminRequestModel>, IValidator<AddAdminRequestModel>
    {
        public AddAdminRequestModelValidator(IValidationDbService validationDbService)
        {
            RuleFor(x => x.EmailAddress)
                .Must(validationDbService.NotUsedEmail_Admin)
                .WithErrorCode(CustomValidationType.AlreadyInUse.ToString());
        }


    }
}
