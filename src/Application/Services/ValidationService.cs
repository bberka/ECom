namespace ECom.Application.Services
{
	public class ValidationService : IValidationService
	{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptionService _optionService;
		private readonly Option _option;
		public ValidationService(
            IUnitOfWork unitOfWork,
			IOptionService optionService
			)
		{
            _unitOfWork = unitOfWork;
            _optionService = optionService;
			_option = _optionService.GetOptionFromCache();
		}

		public bool AllowTester(bool isTesterAccount)
		{
			if (!isTesterAccount) return false;
			return !_option.IsRelease;
		}
		public bool NotUsedEmail_Admin(string email)
		{
			return !_unitOfWork.AdminRepository.Any(x => x.EmailAddress == email);
		}

		public bool NotUsedEmail_User(string email)
		{
			return !_unitOfWork.UserRepository.Any(x => x.EmailAddress == email);
		}

		public bool NotHasSpecialChar(string password)
        {
            return !_option.RequireSpecialCharacterInPassword || password.HasSpecialChars();
        }
		public bool HasNumber(string password)
        {
            return !_option.RequireNumberInPassword || password.Any(char.IsDigit);
        }
		public bool HasLowerCase(string password)
        {
            return !_option.RequireLowerCaseInPassword || password.Any(char.IsLower);
        }
		public bool HasUpperCase(string password)
        {
            return !_option.RequireUpperCaseInPassword || password.Any(char.IsUpper);
        }
		public bool NotHasSpace(string password)
		{
			return password.All(x => x != ' ');
		}


		public bool IsRelease()
		{
			return _option.IsRelease;
		}

	}
}
