namespace ECom.Application.Validators;

public class AddStockChangeRequestValidator : AbstractValidator<AddStockChangeRequest>,
  IValidator<AddStockChangeRequest>
{
  public AddStockChangeRequestValidator() {
    RuleFor(x => x.Cost)
      .GreaterThan(0);

    RuleFor(x => x.Count)
      .GreaterThan(0);

  }
}