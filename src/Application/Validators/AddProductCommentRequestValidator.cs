using ECom.Shared.Extensions;

namespace ECom.Application.Validators;

public class AddProductCommentRequestValidator : AbstractValidator<ProductCommentAddRequestDto>,
  IValidator<ProductCommentAddRequestDto>
{
  public AddProductCommentRequestValidator() {
    RuleFor(x => x.Comment)
      .ApplyProductCommentRule();

  }
}