using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Validators
{
    public class CompanyInformationValidator : AbstractValidator<CompanyInformation>, IValidator<CompanyInformation>
    {
        public CompanyInformationValidator(IValidationDbService validationDbService)
        {

        }
    }
}
