



namespace ECom.Application.Validators
{
	public class RegisterValidator : AbstractValidator<RegisterModel>, IValidator<RegisterModel>
	{
		private readonly IOptionService _optionService;
		private readonly IUserService _userService;

		public RegisterValidator(IOptionService optionService,IUserService userService)
		{
			this._optionService = optionService;
			this._userService = userService;
			RuleFor(x => x.Password)
				.NotNull()
				.NotEmpty();

			RuleFor(x => x.Password)
				.MinimumLength(ConstantMgr.PasswordMinLength);

			RuleFor(x => x.Password)
				.MaximumLength(ConstantMgr.PasswordMaxLength);

			RuleFor(x => x.EmailAddress)
				.NotNull()
				.NotEmpty()
				.EmailAddress();

			RuleFor(x => x.Password)
				.Must(NotHasSpace)
				.WithErrorCode(CustomValidationType.CanNotContainSpace.ToString());

			RuleFor(x => x.Password)
				.Must(NotHasSpecialChar)
				.WithErrorCode(CustomValidationType.MustContainSpecialCharacter.ToString());

			RuleFor(x => x.Password)
				.Must(NotHasNumber)
				.WithErrorCode(CustomValidationType.MustContainDigit.ToString());

			RuleFor(x => x.Password)
				.Must(NotHasLowerCase)
				.WithErrorCode(CustomValidationType.MustContainLowerCase.ToString());

			RuleFor(x => x.Password)
				.Must(NotHasUpperCase)
				.WithErrorCode(CustomValidationType.MustContainUpperCase.ToString());

			RuleFor(x => x.EmailAddress)
				.Must(NotUsedEmail)
				.WithErrorCode(ErrCode.AlreadyInUse.ToString());
		}

		private bool NotUsedEmail(string email)
		{
			return !_userService.Any(x => x.EmailAddress == email);
		}
		private bool NotHasSpecialChar(string password)
		{
			var option = _optionService.GetFromCache();
			if (!option.RequireSpecialCharacterInPassword)
			{
				return true;
			}
			return !EasValidate.HasSpecialChars(password);
		}
		private bool NotHasNumber(string password)
		{
			var option = _optionService.GetFromCache();
			if (!option.RequireNumberInPassword)
			{
				return true;
			}
			return !password.Any(x => char.IsDigit(x));
		}
		private bool NotHasLowerCase(string password)
		{
			var option = _optionService.GetFromCache();
			if (!option.RequireLowerCaseInPassword)
			{
				return true;
			}
			return !password.Any(x => char.IsLower(x));
		}
		private bool NotHasUpperCase(string password)
		{
			var option = _optionService.GetFromCache();
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
