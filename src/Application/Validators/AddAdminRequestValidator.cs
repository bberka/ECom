using ECom.Domain.DTOs.AdminDto;

namespace ECom.Application.Validators;

public class AddAdminRequestValidator : AbstractValidator<AddAdminRequest>, IValidator<AddAdminRequest>
{
  public AddAdminRequestValidator(IValidationService validationService) {
    RuleFor(x => x.EmailAddress)
      .EmailAddress();

    RuleFor(x => x.Password)
      .MinimumLength(6)
      .MaximumLength(32);

    RuleFor(x => x.RoleId)
      .GreaterThan(0);


    //RuleFor(x => x.EmailAddress)
    //  .Must(validationService.NotUsedEmail_Admin)
    //  .WithErrorCode(CustomValidationType.AlreadyInUse.ToString());
  }
}