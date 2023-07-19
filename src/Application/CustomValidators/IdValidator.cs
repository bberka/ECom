using FluentValidation.Validators;

namespace ECom.Application.CustomValidators;

public class IdValidator<T> : PropertyValidator<T, int>
{
  public override string Name => "IdValidator";

  public override bool IsValid(ValidationContext<T> context, int value) {
    if (value <= 0) {
      context.MessageFormatter.AppendArgument("Id", value);
      return false;
    }

    return true;
  }

  protected override string GetDefaultMessageTemplate(string errorCode) {
    return "Invalid id.";
  }
}