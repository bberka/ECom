namespace ECom.Business.Validators;

public class AddProductCommentRequestValidator : AbstractValidator<Request_ProductComment_Add>,
                                                 IValidator<Request_ProductComment_Add>
{
  public AddProductCommentRequestValidator() {
    RuleFor(x => x.Comment)
      .ApplyProductCommentRule();
  }
}