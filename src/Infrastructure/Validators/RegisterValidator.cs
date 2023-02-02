using ECom.Infrastructure.DependencyResolvers.AspNetCore;
using ECom.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ECom.Infrastructure.Validators
{
	public class RegisterValidator : AbstractValidator<RegisterModel>
	{

		public static RegisterValidator This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static RegisterValidator? Instance;
		private RegisterValidator()
		{

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


			RuleFor(x => x.EmailAddress)
				.NotNull()
				.NotEmpty()
				.EmailAddress()
				.WithErrorCode(Response.InvalidEmailAddress.ToString());


			RuleFor(x => x.Password)
				.Must(NotHasSpace)
				.WithErrorCode(Response.PasswordCanNotContainSpace.ToString());

			RuleFor(x => x.Password)
				.Must(NotHasSpecialChar)
				.WithErrorCode(Response.PasswordMustContainSpecialCharacter.ToString());

			RuleFor(x => x.Password)
				.Must(NotHasNumber)
				.WithErrorCode(Response.PasswordMustContainNumber.ToString());

			RuleFor(x => x.Password)
				.Must(NotHasLowerCase)
				.WithErrorCode(Response.PasswordMustContainLowerCase.ToString());

			RuleFor(x => x.Password)
				.Must(NotHasUpperCase)
				.WithErrorCode(Response.PasswordMustContainUpperCase.ToString());

			RuleFor(x => x.EmailAddress)
			.Must(NotExistEmail)
			.WithErrorCode(Response.EmailIsInUse.ToString());
		}

		private bool NotExistEmail(string email)
		{
			var instance = ServiceProviderProxy.GetService<IUserService>();
			return !instance.Any(x => x.EmailAddress == email);
		}
		private bool NotHasSpecialChar(string password)
		{
			var instance = ServiceProviderProxy.GetService<IOptionService>();
			var option = instance.GetFromCache();
			if (!option.RequireSpecialCharacterInPassword)
			{
				return true;
			}
			return !EasValidate.HasSpecialChars(password);
		}
		private bool NotHasNumber(string password)
		{
			var instance = ServiceProviderProxy.GetService<IOptionService>();
			var option = instance.GetFromCache();
			if (!option.RequireNumberInPassword)
			{
				return true;
			}
			return !password.Any(x => char.IsDigit(x));
		}
		private bool NotHasLowerCase(string password)
		{
			var instance = ServiceProviderProxy.GetService<IOptionService>();
			var option = instance.GetFromCache();
			if (!option.RequireLowerCaseInPassword)
			{
				return true;
			}
			return !password.Any(x => char.IsLower(x));
		}
		private bool NotHasUpperCase(string password)
		{
			var instance = ServiceProviderProxy.GetService<IOptionService>();
			var option = instance.GetFromCache();
			if (!option.RequireUpperCaseInPassword)
			{
				return true;
			}
			return !password.Any(x => char.IsUpper(x));
		}
		private bool NotHasSpace(string password)
		{
			return !password.Any(x => x == ' ');
		}
	}
}
