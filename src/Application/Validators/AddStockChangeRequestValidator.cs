using ECom.Shared.Extensions;

namespace ECom.Application.Validators;

public class AddStockChangeRequestValidator : AbstractValidator<StockChangeAddRequestDto>,
  IValidator<StockChangeAddRequestDto>
{
  public AddStockChangeRequestValidator() {
    RuleFor(x => x.Cost)
      .ApplyMoneyRule();

    RuleFor(x => x.Count)
      .ApplyCountRule();

  }
}