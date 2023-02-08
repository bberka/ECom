namespace ECom.Application.Validators
{
	public class AdminValidator : AbstractValidator<Admin>, IValidator<Admin>
	{
		public AdminValidator(IValidationService validationService)
		{
			RuleFor(x => x.EmailAddress)
				.NotEmpty()
				.EmailAddress()
				.WithErrorCode(CustomValidationType.Invalid.ToString());

			RuleFor(x => x.IsValid)
				.Equal(true)
				.WithErrorCode(CustomValidationType.InvalidAccount.ToString());
            
            RuleFor(x => x.IsTestAccount)
                .Equal(!validationService.IsRelease())
                .WithErrorCode(CustomValidationType.AccountCanNotBeUsed.ToString());

			RuleFor(x => x.DeletedDate)
				.Equal(x => null)
				.WithErrorCode(CustomValidationType.Deleted.ToString());
		}
	
		
	}
}
