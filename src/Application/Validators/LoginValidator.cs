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
				.EmailAddress();

			RuleFor(x => x.Password)
				.NotNull()
				.NotEmpty();

			RuleFor(x => x.Password)
				.MinimumLength(ConstantMgr.PasswordMinLength);

			RuleFor(x => x.Password)
				.MaximumLength(ConstantMgr.PasswordMaxLength);
		}

	}
}
