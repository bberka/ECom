namespace ECom.Shared.DTOs;

public class RegisterUserRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public int? CitizenshipNumber { get; set; }
    public int? TaxNumber { get; set; }
    public int PreferredLanguage { get; set; }
}