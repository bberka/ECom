namespace ECom.Application.Validators
{
	public class AdminValidator : AbstractValidator<Admin>, IValidator<Admin>
	{
		public AdminValidator(IValidationDbService validationDbService)
		{
			RuleFor(x => x.EmailAddress)
				.NotNull()
				.NotEmpty()
				.EmailAddress()
				.WithErrorCode(CustomValidationType.Invalid.ToString());

			RuleFor(x => x.IsValid)
				.Equal(x => true)
				.WithErrorCode(CustomValidationType.InvalidAccount.ToString());

			if (validationDbService.IsRelease())
			{
				RuleFor(x => x.IsTestAccount)
				.Equal(x => false)
				.WithErrorCode(CustomValidationType.AccountCanNotBeUsed.ToString());
			}
			else
			{
				RuleFor(x => x.IsTestAccount)
				.Equal(x => true)
				.WithErrorCode(CustomValidationType.AccountCanNotBeUsed.ToString());
			}


			RuleFor(x => x.DeletedDate)
				.Equal(x => null)
				.WithErrorCode(CustomValidationType.Deleted.ToString());
		}
	
		
	}
}
