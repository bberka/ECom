using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services;
using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Entities;

namespace ECom.Application.Services;

public class ValidationService : IValidationService
{
    protected readonly Option Option;
    protected readonly IOptionService OptionService;
    protected readonly IUnitOfWork UnitOfWork;

    public ValidationService(
      IUnitOfWork unitOfWork,
      IOptionService optionService
    )
    {
        UnitOfWork = unitOfWork;
        OptionService = optionService;
        Option = OptionService.GetOption();
    }
    public bool NotUsedEmail_Admin(string email)
    {
        return !UnitOfWork.AdminRepository.Any(x => x.EmailAddress == email);
    }

    public bool NotUsedEmail_User(string email)
    {
        return !UnitOfWork.UserRepository.Any(x => x.EmailAddress == email);
    }



    public bool NotHasSpecialChar(string password)
    {
        return !Option.RequireSpecialCharacterInPassword || password.ContainsSpecialChars();
    }

    public bool HasNumber(string password)
    {
        return !Option.RequireNumberInPassword || password.Any(char.IsDigit);
    }

    public bool HasLowerCase(string password)
    {
        return !Option.RequireLowerCaseInPassword || password.Any(char.IsLower);
    }

    public bool HasUpperCase(string password)
    {
        return !Option.RequireUpperCaseInPassword || password.Any(char.IsUpper);
    }

    public bool NotHasSpace(string password)
    {
        return password.All(x => x != ' ');
    }


}