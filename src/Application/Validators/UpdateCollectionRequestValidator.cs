using ECom.Domain.DTOs.CollectionDTOs;

namespace ECom.Application.Validators;

public class UpdateCollectionRequestValidator : AbstractValidator<UpdateCollectionRequest>,
  IValidator<UpdateCollectionRequest>
{
  public UpdateCollectionRequestValidator() {
    RuleFor(x => x.CollectionName)
      .MinimumLength(3)
      .MaximumLength(32);

    RuleFor(x => x.CollectionId)
      .GreaterThan(0);
  }
}