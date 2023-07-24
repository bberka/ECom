namespace ECom.Application.Validators;

public class AddStockChangeRequestValidator : AbstractValidator<AddStockChangeRequest>,
  IValidator<AddStockChangeRequest>
{
  public AddStockChangeRequestValidator() {
    RuleFor(x => x.Cost)
      .ApplyMoneyRule();

    RuleFor(x => x.Count)
      .ApplyCountRule();

  }
}