namespace ECom.Application.Validators
{
	public class AdminValidator : AbstractValidator<Admin>, IValidator<Admin>
	{
		private readonly IOptionService _optionService;
		public AdminValidator(IOptionService optionService)
		{
			this._optionService = optionService;
			RuleFor(x => x.EmailAddress)
				.NotNull()
				.NotEmpty()
				.EmailAddress()
				.WithErrorCode("InvalidData:EmailAddress");

			RuleFor(x => x.IsValid)
				.Equal(x => false)
				.WithErrorCode("Invalid:Account");	

			RuleFor(x => x.IsTestAccount)
				.Equal(x => true)
				.Must(DebugModeOn)
				.WithErrorCode("CanNotBeUsed:DebugAccount");

			RuleFor(x => x.IsEmailVerified)
				.Equal(x => false)
				.WithErrorCode("NotVerified:Email");

			RuleFor(x => x.DeletedDate)
				.NotEqual(x => null)
				.WithErrorCode("Deleted:Account");
		}
		private bool DebugModeOn(bool isTesterAccount)
		{
			if (!isTesterAccount) return false;
			var option = _optionService.GetFromCache();
			return !option.IsRelease;
		}

		
	}
}
