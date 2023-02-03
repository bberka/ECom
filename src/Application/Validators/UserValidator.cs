


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
				.EmailAddress()
				.WithErrorCode("InvalidData");

			RuleFor(x => x.IsValid)
				.Equal(x => false)
				.WithErrorCode("NotValid");	

			RuleFor(x => x.IsTestAccount)
				.Equal(x => true)
				.Must(DebugModeOn)
				.WithErrorCode("CanNotBeUsed");

			RuleFor(x => x.IsEmailVerified)
				.Equal(x => false)
				.WithErrorCode("NotVerified");

			RuleFor(x => x.DeletedDate)
				.NotEqual(x => null)
				.WithErrorCode("Deleted");
		}
		private bool DebugModeOn(bool isTesterAccount)
		{
			if (!isTesterAccount) return false;
			var option = _optionService.GetFromCache();
			return !option.IsRelease;
		}

		
	}
}
