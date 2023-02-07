


using FluentValidation;

namespace ECom.Application.Validators
{
	public class UserValidator : AbstractValidator<User>, IValidator<User>
	{
		public UserValidator()
		{

			RuleFor(x => x.EmailAddress)
				.NotNull()
				.NotEmpty()
				.EmailAddress();

			RuleFor(x => x.IsValid)
				.Equal(x => true)
				.WithErrorCode(CustomValidationType.InvalidAccount.ToString());

			if (!ConstantMgr.IsDebug())
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
