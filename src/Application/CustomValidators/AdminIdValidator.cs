using FluentValidation.Validators;

namespace ECom.Application.CustomValidators;

public class AdminIdValidator<T> : PropertyValidator<T, int>
{
  private readonly IAdminService _adminService;

  public AdminIdValidator(IAdminService adminService) {
    _adminService = adminService;
  }

  public override string Name => "AdminIdValidator";

  public override bool IsValid(ValidationContext<T> context, int value) {
    if (value <= 0) {
      context.MessageFormatter.AppendArgument("AdminId", value);
      return false;
    }

    var exist = _adminService.AdminExists(value);
    if (!exist) {
      context.MessageFormatter.AppendArgument("AdminId", value);
      return false;
    }

    return true;
  }

  protected override string GetDefaultMessageTemplate(string errorCode) {
    return "Admin account not found.";
  }
}

