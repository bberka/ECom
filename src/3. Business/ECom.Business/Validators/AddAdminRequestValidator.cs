namespace ECom.Business.Validators;

public class AddAdminRequestValidator : AbstractValidator<Request_Admin_Add>
{
  public AddAdminRequestValidator(IValidationService validationService) {
    RuleFor(x => x.EmailAddress)
      .EmailAddress();
    RuleFor(x => x.Password)
      .ApplyPasswordRule();
    //RuleFor(x => x.RoleId)
    //  .ApplyRoleRule();
  }
}