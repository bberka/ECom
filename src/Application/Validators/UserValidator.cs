using ECom.Application.BaseManager;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Validators
{
	public class UserValidator : AbstractValidator<User>
	{

		public static UserValidator This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static UserValidator? Instance;
		private UserValidator()
		{
			RuleFor(x => x.Username)
				.NotNull()
				.NotEmpty()
				.WithErrorCode(Response.UsernameRequired.ToString());

			
		}

		public bool NotExistUsername(string username)
		{
			return !UserMgr.This.Any(x => x.Username == username);
		}
		public bool NotExistEmail(string username)
		{
			return !UserMgr.This.Any(x => x.Username == username);
		}

	}
}
