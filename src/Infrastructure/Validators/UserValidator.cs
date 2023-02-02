namespace ECom.Infrastructure.Validators
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
			RuleFor(x => x.EmailAddress)
				.NotNull()
				.NotEmpty()
				.EmailAddress()
				.WithErrorCode(Response.InvalidEmailAddress.ToString());

			RuleFor(x => x.IsValid)
				.Equal(x => false)
				.WithErrorCode(Response.AccountIsNotValid.ToString());	

			RuleFor(x => x.IsTestAccount)
				.Equal(x => true)
				.Must(DebugModeOn)
				.WithErrorCode(Response.DebugAccountCanNotBeUsed.ToString());

			RuleFor(x => x.IsEmailVerified)
				.Equal(x => false)
				.WithErrorCode(Response.EmailIsNotVerified.ToString());

			RuleFor(x => x.DeletedDate)
				.NotEqual(x => null)
				.WithErrorCode(Response.AccountIsDeleted.ToString());
		}
		private bool DebugModeOn(bool isTesterAccount)
		{
			if (!isTesterAccount) return false;
			var option = OptionDal.This.Cache.Get();
			return option.IsDebug;
		}

		
	}
}
