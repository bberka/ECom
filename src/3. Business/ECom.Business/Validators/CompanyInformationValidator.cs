namespace ECom.Business.Validators;

public class CompanyInformationValidator : AbstractValidator<CompanyInformation>,
                                           IValidator<CompanyInformation>
{
  public CompanyInformationValidator(IValidationService validationService) { }
}