using FluentValidation.Validators;

namespace ECom.Application.CustomValidators;

public class IdValidator<T> : PropertyValidator<T,int>
{

  public override bool IsValid(ValidationContext<T> context, int value) {
    if (value <= 0) {
      context.MessageFormatter.AppendArgument("Id", value);
      return false;
    }
    return true;
  }

  public override string Name => "IdValidator";

  protected override string GetDefaultMessageTemplate(string errorCode)
    => "Invalid id.";

}