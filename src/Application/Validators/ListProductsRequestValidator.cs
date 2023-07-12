using ECom.Domain.DTOs.ProductDTOs;

namespace ECom.Application.Validators;

public class ListProductsRequestValidator : AbstractValidator<ListProductsRequest>, IValidator<ListProductsRequest>
{
  public ListProductsRequestValidator() {
    RuleFor(x => x.Page)
      .GreaterThan(0);
  }
}