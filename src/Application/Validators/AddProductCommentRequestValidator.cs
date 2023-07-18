using ECom.Domain.DTOs.ProductDto;

namespace ECom.Application.Validators;

public class AddProductCommentRequestValidator : AbstractValidator<AddProductCommentRequest>,
  IValidator<AddProductCommentRequest>
{
  public AddProductCommentRequestValidator() {
    RuleFor(x => x.Comment)
      .MinimumLength(8)
      .MaximumLength(1000);

    RuleFor(x => x.ProductId)
      .GreaterThan(0);
  }
}