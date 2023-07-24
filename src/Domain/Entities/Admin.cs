

namespace ECom.Domain.Entities;

[Table("Admins", Schema = "ECOperation")]
public class Admin : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime? UpdateDate { get; set; }
  public DateTime? DeleteDate { get; set; }

  [MinLength(ValidationSettings.MinHashedPasswordLength)]
  [MaxLength(ValidationSettings.MaxHashedPasswordLength)]
  public string Password { get; set; }
  
  [EmailAddress]
  [MaxLength(ValidationSettings.MaxEmailLength)]
  public string EmailAddress { get; set; }


  [MaxLength(255)]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  [IgnoreDataMember]
  public string? TwoFactorKey { get; set; }

  public TwoFactorType TwoFactorType { get; set; }
  
  public bool IsDeleted => DeleteDate.HasValue;

  public string RoleId { get; set; }

  [MaxLength(ValidationSettings.MaxTokenLength)]
  public string? RefreshJwtToken { get; set; } = null;
  //virtual
  public Role Role { get; set; } = null!;
  public virtual List<AdminLog> AdminLogs { get; set; }


  public static AdminDto ToDto(Admin? admin) {
    return new AdminDto {
      Id = admin.Id,
      EmailAddress = admin.EmailAddress,
      TwoFactorType = admin.TwoFactorType,
      //Permissions = string.Join(",", admin.Role.Permissions.Select(x => x.Name).ToArray()),
      RoleId = admin.RoleId,
      DeletedDate = admin.DeleteDate,
      Permissions = admin.Role?.PermissionRoles?.Select(x => x.Permission.Id)?.ToArray() ?? Array.Empty<string>(),
      Password = admin.Password,
      RegisterDate = admin.RegisterDate,
      
    };
  }

  public static Admin FromDto(AdminDto adminDto) {
    return new Admin {
      EmailAddress = adminDto.EmailAddress,
      TwoFactorType = adminDto.TwoFactorType,
      Id = adminDto.Id,
      RoleId = adminDto.RoleId,
      Password = adminDto.Password,
      RegisterDate = adminDto.RegisterDate,
      DeleteDate = adminDto.DeletedDate,
    };
  }

  public static Admin FromDto(AddAdminRequest request) {
    return new Admin {
      RegisterDate = DateTime.Now,
      DeleteDate = null,
      EmailAddress = request.EmailAddress,
      TwoFactorType = 0,
      RoleId = request.RoleId,
      Password = request.Password.ToHashedText(),
    };
  }
}