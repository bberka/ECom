using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Validators
{
    public class UpdateCollectionRequestValidator : AbstractValidator<UpdateCollectionRequest>, IValidator<UpdateCollectionRequest>
    {
        public UpdateCollectionRequestValidator()
        {
            RuleFor(x => x.CollectionName)
                .MinimumLength(3)
                .MaximumLength(32);

            RuleFor(x => x.CollectionId)
                .GreaterThan(0);
        }
    }
}
