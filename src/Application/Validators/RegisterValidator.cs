﻿



using ECom.Domain.ApiModels.Request;

namespace ECom.Application.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterRequestModel>, IValidator<RegisterRequestModel>
	{
		private readonly IValidationDbService _validationDbService;
		public RegisterValidator(IValidationDbService validationDbService)
		{
			this._validationDbService = validationDbService;
			
			RuleFor(x => x.Password)
				.NotNull()
				.NotEmpty();

			RuleFor(x => x.Password)
				.MinimumLength(ConstantMgr.StringMinLength);

			RuleFor(x => x.Password)
				.MaximumLength(ConstantMgr.PasswordMaxLength);

			RuleFor(x => x.EmailAddress)
				.NotNull()
				.NotEmpty()
				.EmailAddress();

			RuleFor(x => x.Password)
				.Must(_validationDbService.NotHasSpace)
				.WithErrorCode(CustomValidationType.CanNotContainSpace.ToString());

			RuleFor(x => x.Password)
				.Must(_validationDbService.NotHasSpecialChar)
				.WithErrorCode(CustomValidationType.MustContainSpecialCharacter.ToString());

			RuleFor(x => x.Password)
				.Must(_validationDbService.HasNumber)
				.WithErrorCode(CustomValidationType.MustContainDigit.ToString());

			RuleFor(x => x.Password)
				.Must(_validationDbService.HasLowerCase)
				.WithErrorCode(CustomValidationType.MustContainLowerCase.ToString());

			RuleFor(x => x.Password)
				.Must(_validationDbService.HasUpperCase)
				.WithErrorCode(CustomValidationType.MustContainUpperCase.ToString());

			RuleFor(x => x.EmailAddress)
				.Must(_validationDbService.NotUsedEmail_User)
				.WithErrorCode(CustomValidationType.AlreadyInUse.ToString());
		}


	}
}
