using ECom.Foundation.Enum;

namespace ECom.Foundation.DTOs.Request;

public sealed class Request_User_Register
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string EmailAddress { get; set; }
  public string Password { get; set; }
  public string PhoneNumber { get; set; }
  public int? CitizenshipNumber { get; set; }
  public LanguageType PreferredLanguage { get; set; }
}