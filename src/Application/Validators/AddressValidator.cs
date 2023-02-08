



namespace ECom.Application.Validators
{
	public class AddressValidator : AbstractValidator<Address>, IValidator<Address>
	{
		public AddressValidator(IValidationService validationService)
		{
			
			RuleFor(x => x.DeleteDate)
				.Equal(x => null)
				.WithErrorCode(CustomValidationType.Deleted.ToString());

			//RuleFor(x => x.UserId)
			//	.NotEqual(x => null)
			//	.WithErrorCode(CustomValidationType.Null.ToString());

		}


	}
}
