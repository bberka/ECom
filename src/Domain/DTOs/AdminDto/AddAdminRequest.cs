using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ECom.Domain.DTOs.AdminDto;

public class AddAdminRequest : BaseAuthenticatedRequest
{
  public string EmailAddress { get; set; }

  public string Password { get; set; }

  public int RoleId { get; set; }

  [IgnoreDataMember]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  public string EncryptedPassword => Password.ToEncryptedText();

  public Entities.Admin ToAdminEntity() {
    return new Entities.Admin {
      RegisterDate = DateTime.Now,
      DeletedDate = null,
      EmailAddress = EmailAddress,
      Password = EncryptedPassword,
      TwoFactorType = 0,
      RoleId = RoleId
    };
  }
}