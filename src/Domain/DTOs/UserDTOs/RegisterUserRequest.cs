using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ECom.Domain.DTOs.UserDTOs;

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

  [IgnoreDataMember]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  public string EncryptedPassword => Password.ToEncryptedText();

  public User ToUserEntity() {
    return new User {
      CitizenShipNumber = CitizenshipNumber,
      RegisterDate = DateTime.Now,
      DeletedDate = null,
      EmailAddress = EmailAddress,
      PhoneNumber = PhoneNumber,
      Password = Convert.ToBase64String(Password.MD5Hash()),
      IsEmailVerified = false,
      IsValid = true,
      TaxNumber = TaxNumber,
      TwoFactorType = 0,
      Culture = "en",
      FirstName = FirstName,
      LastName = LastName
    };
  }
}