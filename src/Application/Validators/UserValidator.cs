﻿


namespace ECom.Application.Validators
{
	public class UserValidator : AbstractValidator<User>, IValidator<User>
	{
		private readonly IOptionService _optionService;
		public UserValidator(IOptionService optionService)
		{
			_optionService = optionService;
			RuleFor(x => x.EmailAddress)
				.NotNull()
				.NotEmpty()
				.EmailAddress();

			RuleFor(x => x.IsValid)
				.Equal(x => false)
				.WithErrorCode(CustomValidationType.InvalidAccount.ToString());	

			RuleFor(x => x.IsTestAccount)
				.Equal(x => true)
				.Must(DebugModeOn)
				.WithErrorCode(CustomValidationType.TestAccountCanNotBeUsed.ToString());

			RuleFor(x => x.IsEmailVerified)
				.Equal(x => false)
				.WithErrorCode(CustomValidationType.TestAccountCanNotBeUsed.ToString());

			RuleFor(x => x.DeletedDate)
				.NotEqual(x => null)
				.WithErrorCode(CustomValidationType.Deleted.ToString());
		}
		private bool DebugModeOn(bool isTesterAccount)
		{
			if (!isTesterAccount) return false;
			var option = _optionService.GetFullOptionCache().Option;
			return !option.IsRelease;
		}

		
	}
}
