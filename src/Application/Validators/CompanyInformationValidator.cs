using ECom.Shared.Abstract.Services;
using ECom.Shared.Entities;

namespace ECom.Application.Validators;

public class CompanyInformationValidator : AbstractValidator<CompanyInformation>, IValidator<CompanyInformation>
{
  public CompanyInformationValidator(IValidationService validationService) {
  }
}