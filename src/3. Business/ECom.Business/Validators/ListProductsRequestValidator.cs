namespace ECom.Business.Validators;

public class ListProductsRequestValidator : AbstractValidator<Request_Product_List>,
                                            IValidator<Request_Product_List>
{
  public ListProductsRequestValidator() {
    RuleFor(x => x.Page)
      .GreaterThan(0);
  }
}