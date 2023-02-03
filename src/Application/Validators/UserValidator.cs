


namespace ECom.Application.Validators
{
	public class UserValidator : AbstractValidator<User>, IValidator<User>
	{
		private readonly IValidationDbService _validationDbService;

		public UserValidator(IValidationDbService validationDbService)
		{
			this._validationDbService = validationDbService;

			RuleFor(x => x.EmailAddress)
				.NotNull()
				.NotEmpty()
				.EmailAddress();

			RuleFor(x => x.IsValid)
				.Equal(x => false)
				.WithErrorCode(CustomValidationType.InvalidAccount.ToString());	

			RuleFor(x => x.IsTestAccount)
				.Equal(x => true)
				.Must(_validationDbService.AllowTester)
				.WithErrorCode(CustomValidationType.TestAccountCanNotBeUsed.ToString());

			RuleFor(x => x.IsEmailVerified)
				.Equal(x => false)
				.WithErrorCode(CustomValidationType.TestAccountCanNotBeUsed.ToString());

			RuleFor(x => x.DeletedDate)
				.NotEqual(x => null)
				.WithErrorCode(CustomValidationType.Deleted.ToString());
		}
		
		
	}
}
