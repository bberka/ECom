using FluentValidation;

namespace ECom.Application.Validators
{
	public class LoginValidator : AbstractValidator<LoginModel>, IValidator<LoginModel>
	{
		public LoginValidator()
		{

			RuleFor(x => x.EmailAddress)
				.NotEmpty()
				.NotNull()
				.EmailAddress()
				.WithErrorCode("InvalidData:Email");

			RuleFor(x => x.Password)
				.NotNull()
				.NotEmpty()
				.WithErrorCode("Required:Password");

			RuleFor(x => x.Password)
				.MinimumLength(ConstantMgr.PasswordMinLength)
				.WithErrorCode("TooShort:Password");

			RuleFor(x => x.Password)
				.MaximumLength(ConstantMgr.PasswordMaxLength)
				.WithErrorCode("TooLong:Password");
		}

	}
}
