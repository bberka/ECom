



namespace ECom.Application.Validators
{
	public class AddressValidator : AbstractValidator<Address>, IValidator<Address>
	{
		private readonly IValidationDbService _validationDbService;
		public AddressValidator(IValidationDbService validationDbService)
		{
			this._validationDbService = validationDbService;
			
			RuleFor(x => x.DeleteDate)
				.Equal(x => null)
				.WithErrorCode(CustomValidationType.Deleted.ToString());

			RuleFor(x => x.UserId)
				.Equal(x => null)
				.WithErrorCode(CustomValidationType.Null.ToString());

		}


	}
}
