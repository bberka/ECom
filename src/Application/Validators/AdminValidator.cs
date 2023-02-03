namespace ECom.Application.Validators
{
	public class AdminValidator : AbstractValidator<Admin>, IValidator<Admin>
	{
		private readonly IValidationDbService _validationDbService;
		public AdminValidator(IValidationDbService validationDbService)
		{
			this._validationDbService = validationDbService;
			RuleFor(x => x.EmailAddress)
				.NotNull()
				.NotEmpty()
				.EmailAddress()
				.WithErrorCode(CustomValidationType.Invalid.ToString());

			RuleFor(x => x.IsValid)
				.Equal(x => false)
				.WithErrorCode(CustomValidationType.InvalidAccount.ToString());	

			RuleFor(x => x.IsTestAccount)
				.Equal(x => true)
				.Must(_validationDbService.AllowTester)
				.WithErrorCode(CustomValidationType.TestAccountCanNotBeUsed.ToString());

			RuleFor(x => x.IsEmailVerified)
				.Equal(x => false)
				.WithErrorCode(CustomValidationType.NotVerified.ToString());

			RuleFor(x => x.DeletedDate)
				.NotEqual(x => null)
				.WithErrorCode(CustomValidationType.Deleted.ToString());
		}
	
		
	}
}
