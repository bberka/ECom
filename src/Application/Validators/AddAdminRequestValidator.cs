using ECom.Domain.Abstract.Services;
using ECom.Shared.Constants;
using Microsoft.AspNetCore.Routing;

namespace ECom.Application.Validators;

public class AddAdminRequestValidator : AbstractValidator<AddAdminRequest>
{
  public AddAdminRequestValidator(IValidationService validationService) {
    RuleFor(x => x.EmailAddress)
      .EmailAddress();
    RuleFor(x => x.Password)
      .ApplyPasswordRule();
    RuleFor(x => x.RoleId)
      .ApplyRoleRule();


  }
}