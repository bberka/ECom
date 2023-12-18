namespace ECom.Business.Validators;

public class ListProductsByCategoryRequestValidator : AbstractValidator<Request_Product_ListByCategory>,
                                                      IValidator<Request_Product_ListByCategory>
{
  public ListProductsByCategoryRequestValidator() {
    RuleFor(x => x.Page)
      .GreaterThan(0);

    RuleFor(x => x.CategoryId)
      .GreaterThan(0);
  }
}