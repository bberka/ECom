


using FluentValidation;

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
				.Equal(x => true)
				.WithErrorCode(CustomValidationType.InvalidAccount.ToString());

			if (_validationDbService.IsRelease())
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
			
			RuleFor(x => x.IsEmailVerified)
				.Equal(x => true)
				.WithErrorCode(CustomValidationType.NotVerified.ToString())
				.WithName("Email Address");


			RuleFor(x => x.DeletedDate)
				.Equal(x => null)
				.WithErrorCode(CustomValidationType.Deleted.ToString());
		}
		
		
	}
}
