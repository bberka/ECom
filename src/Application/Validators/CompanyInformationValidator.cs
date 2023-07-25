using ECom.Domain.Abstract.Services;
using ECom.Domain.Entities;

namespace ECom.Application.Validators;

public class CompanyInformationValidator : AbstractValidator<CompanyInformation>, IValidator<CompanyInformation>
{
  public CompanyInformationValidator(IValidationService validationService) {
  }
}