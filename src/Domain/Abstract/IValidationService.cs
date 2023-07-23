namespace ECom.Domain.Abstract;

public interface IValidationService
{
  bool HasLowerCase(string password);
  bool HasNumber(string password);
  bool NotHasSpace(string password);
  bool NotHasSpecialChar(string password);
  bool HasUpperCase(string password);
  bool NotUsedEmail_Admin(string email);
  bool NotUsedEmail_User(string email);
}