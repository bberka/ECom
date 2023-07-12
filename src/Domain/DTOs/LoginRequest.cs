using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ECom.Domain.DTOs;

public class LoginRequest
{
  public string EmailAddress { get; set; }
  public string Password { get; set; }

  [IgnoreDataMember]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  public string EncryptedPassword => Password.ToEncryptedText();
}