using ECom.Infrastructure.Common;

namespace ECom.Infrastructure.Validators
{
	public static class UserValidator
	{
		public static bool ValidateUsername(string input)
		{
			if (input.Length < OptionHelper.Option.Get().UsernameMinLength)
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
			if (input.Length < OptionHelper.Option.Get().PasswordMinLength)
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
