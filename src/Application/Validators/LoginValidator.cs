using ECom.Domain.DTOs.Request;
using FluentValidation;

namespace ECom.Application.Validators
{
    public class LoginValidator : AbstractValidator<LoginRequest>, IValidator<LoginRequest>
	{
		public LoginValidator()
		{
			RuleFor(x => x.EmailAddress)
				.EmailAddress();

			RuleFor(x => x.Password)
                .MinimumLength(6)
                .MaximumLength(32);

		}

	}
}
