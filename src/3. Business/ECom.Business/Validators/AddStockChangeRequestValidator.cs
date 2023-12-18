namespace ECom.Business.Validators;

public class AddStockChangeRequestValidator : AbstractValidator<Request_StockChange_Add>,
                                              IValidator<Request_StockChange_Add>
{
  public AddStockChangeRequestValidator() {
    RuleFor(x => x.Cost)
      .ApplyMoneyRule();

    RuleFor(x => x.Count)
      .ApplyCountRule();
  }
}