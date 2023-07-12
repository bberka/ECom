﻿using ECom.Domain.DTOs.AdminDTOs;

namespace ECom.Application.Validators;

public class UpdateAdminAccountRequestValidator : AbstractValidator<UpdateAdminAccountRequest>,
  IValidator<UpdateAdminAccountRequest>
{
  public UpdateAdminAccountRequestValidator(IValidationService validationService) {
    RuleFor(x => x.EmailAddress)
      .EmailAddress();

    RuleFor(x => x.EmailAddress)
      .Must(validationService.NotUsedEmail_Admin)
      .WithErrorCode(CustomValidationType.AlreadyInUse.ToString());
  }
}