using System.Text.Json.Serialization;

namespace ECom.Domain.DTOs.AdminDto;

public class AdminDto
{
  public DateTime RegisterDate { get; set; }
  public int Id { get; set; }
  public string EmailAddress { get; set; }
  public byte TwoFactorType { get; set; }
  public int RoleId { get; set; }

  public string RoleName { get; set; }
  public string[] Permissions { get; set; }

  [NotMapped]
  [JsonIgnore]
  [Newtonsoft.Json.JsonIgnore]
  public string Password { get; set; }




  public DateTime? DeletedDate { get; set; }
  public string GetPermissionsString() {
    return string.Join(",", Permissions);
  }

  public static AdminDto FromEntity(Entities.Admin admin) {
    return new AdminDto {
      Id = admin.Id,
      EmailAddress = admin.EmailAddress,
      TwoFactorType = admin.TwoFactorType,
      //Permissions = string.Join(",", admin.Role.Permissions.Select(x => x.Name).ToArray()),
      RoleName = admin.Role.Name,
      RoleId = admin.Role.Id,
      DeletedDate = admin.DeletedDate,
      Permissions = admin.Role?.PermissionRoles?.Select(x => x.Permission.Name)?.ToArray() ?? Array.Empty<string>(),
      Password = admin.Password,
      RegisterDate = admin.RegisterDate,
    };
  }

  public Entities.Admin ToEntity() {
    return new Entities.Admin {
      EmailAddress = EmailAddress,
      TwoFactorType = TwoFactorType,
      Id = Id,
      RoleId = RoleId,
      Password = Password,
      RegisterDate = RegisterDate,
      DeletedDate = DeletedDate,
      TwoFactor = (TwoFactorType)TwoFactorType,
    };
  }
}