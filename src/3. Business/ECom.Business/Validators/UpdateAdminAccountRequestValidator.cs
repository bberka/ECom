namespace ECom.Business.Validators;

public class UpdateAdminAccountRequestValidator : AbstractValidator<Request_Admin_UpdateAccount>,
                                                  IValidator<Request_Admin_UpdateAccount>
{
  public UpdateAdminAccountRequestValidator(IValidationService validationService) {
    RuleFor(x => x.EmailAddress)
      .EmailAddress();

    //RuleFor(x => x.EmailAddress)
    //  .Must(validationService.NotUsedEmail_Admin)
    //  .WithErrorCode(CustomValidationType.AlreadyInUse.ToString());
  }
}