﻿using ECom.Domain.Abstract.Services;

namespace ECom.Application.Validators;

public class CategoryUpdateRequestValidator : AbstractValidator<AddOrUpdateCategoryRequest>
{
  public CategoryUpdateRequestValidator(IValidationService validationService) {
    RuleFor(x => x.Name)
      .ApplyNameRule();
  }
}