using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Validators
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>, IValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
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
}
