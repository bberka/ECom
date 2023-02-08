using ECom.Domain.ApiModels.Request;
using FluentValidation;

namespace ECom.Application.Validators
{
    public class LoginValidator : AbstractValidator<LoginRequestModel>, IValidator<LoginRequestModel>
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
