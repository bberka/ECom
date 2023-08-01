using ECom.Shared.Abstract.Services;
using ECom.Shared.Constants;
using ECom.Shared.Extensions;
using Microsoft.AspNetCore.Routing;

namespace ECom.Application.Validators;

public class AddAdminRequestValidator : AbstractValidator<AdminAddRequestDto>
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