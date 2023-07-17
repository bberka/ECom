﻿using ECom.Domain.DTOs.CategoryDTOs;

namespace ECom.Application.Validators;

public class UpdateCategoryRequestValidator : AbstractValidator<AddOrUpdateCategoryRequest>,
  IValidator<AddOrUpdateCategoryRequest>
{
  public UpdateCategoryRequestValidator() {
    RuleFor(x => x.Name)
      .MinimumLength(3)
      .MinimumLength(64);

    RuleFor(x => x.Name)
      .Length(2);


  }
}