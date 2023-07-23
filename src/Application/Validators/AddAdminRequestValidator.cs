using ECom.Shared.Constants;
using Microsoft.AspNetCore.Routing;

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
      .Must(x => {
        var values = Enum.GetValues(typeof(RoleType));
        foreach (var value in values) {
          var role = (RoleType)value;
          var isMatch = role.ToString().Equals(x, StringComparison.OrdinalIgnoreCase);
          if (isMatch)
            return true;
        }
        return false;
      });


  }
}