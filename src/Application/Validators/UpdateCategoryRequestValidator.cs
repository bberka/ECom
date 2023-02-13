using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Validators
{
    public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>, IValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3)
                .MinimumLength(64);

            RuleFor(x => x.Culture)
                .Length(2);

            RuleFor(x => x.CategoryId)
                .GreaterThan(0);

        }


    }
}
