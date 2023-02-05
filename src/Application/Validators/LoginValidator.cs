using ECom.Domain.ApiModels.Request;
using FluentValidation;

namespace ECom.Application.Validators
{
    public class LoginValidator : AbstractValidator<LoginRequestModel>, IValidator<LoginRequestModel>
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
				.MinimumLength(ConstantMgr.StringMinLength);

			RuleFor(x => x.Password)
				.MaximumLength(ConstantMgr.PasswordMaxLength);
		}

	}
}
