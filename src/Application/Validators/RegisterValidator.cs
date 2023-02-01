using ECom.Application.BaseManager;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Validators
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
			RuleFor(x => x.Username)
				.NotNull()
				.NotEmpty()
				.WithErrorCode(Response.UsernameRequired.ToString());

			RuleFor(x => x.Username)
				.MinimumLength(ConstantMgr.UsernameMinLength)
				.WithErrorCode(Response.UsernameTooShort.ToString());

			RuleFor(x => x.Username)
				.MaximumLength(ConstantMgr.UsernameMaxLength)
				.WithErrorCode(Response.UsernameTooLong.ToString());

			RuleFor(x => x.Username)
				.NotEqual(x => x.EmailAddress)
				.WithErrorCode(Response.UsernameCanNotBeEqualEmail.ToString());

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

			RuleFor(x => x.Password)
				.NotEqual(x => x.Username)
				.WithErrorCode(Response.PasswordCanNotBeEqualUsername.ToString());

			RuleFor(x => x.EmailAddress)
				.NotNull()
				.NotEmpty()
				.EmailAddress()
				.WithErrorCode(Response.InvalidEmailAddress.ToString());


			RuleFor(x => x.Username)
				.Must(NotExistUsername)
				.WithErrorCode(Response.UsernameIsInUse.ToString());

			RuleFor(x => x.EmailAddress)
				.Must(NotExistEmail)
				.WithErrorCode(Response.EmailIsInUse.ToString());
		}
		public bool NotExistUsername(string username)
		{
			return !UserMgr.This.Any(x => x.Username == username);
		}
		public bool NotExistEmail(string email)
		{
			return !UserMgr.This.Any(x => x.Email == email);
		}


	}
}
