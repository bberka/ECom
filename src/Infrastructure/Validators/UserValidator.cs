using Domain.Constants;
using Domain.Interfaces;
using Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validators
{
	public static class UserValidator
	{
		public static bool ValidateUsername(string input)
		{
			if (input.Length < DbCacheHelper.Option.Get().UsernameMinLength)
			{
				return false;
			}
			if (input.Length > Constants.UsernameMaxLength)
			{
				return false;
			}
			return true;
		}
		public static bool ValidatePassword(string input)
		{
			if (input.Length < DbCacheHelper.Option.Get().PasswordMinLength)
			{
				return false;
			}
			if (input.Length > Constants.PasswordMaxLength)
			{
				return false;
			}
			return true;
		}
	}
}
