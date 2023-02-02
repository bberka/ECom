namespace ECom.Infrastructure.Validators
{
	public class LoginValidator : AbstractValidator<LoginModel>
	{

		public static LoginValidator This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static LoginValidator? Instance;

		private LoginValidator()
		{

			RuleFor(x => x.EmailAddress)
				.NotEmpty()
				.NotNull()
				.EmailAddress()
				.WithErrorCode(Response.InvalidEmailAddress.ToString());

			RuleFor(x => x.Password)
				.NotNull()
				.NotEmpty()
				.WithErrorCode(Response.PasswordRequired.ToString());

			RuleFor(x => x.Password)
				.MinimumLength(ConstantMgr.PasswordMinLength)
				.WithErrorCode(Response.PasswordTooShort.ToString());

			RuleFor(x => x.Password)
				.MaximumLength(ConstantMgr.PasswordMaxLength)
				.WithErrorCode(Response.PasswordTooLong.ToString());
		}

	}
}
