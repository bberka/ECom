

namespace ECom.Domain.Entities;

[Table("Admins", Schema = "ECOperation")]
public class Admin : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.Now;

  //public bool IsValid { get; set; } = true;


  [MaxLength(64)]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  [IgnoreDataMember]
  public string Password { get; set; }

  [MaxLength(ConstantMgr.EmailMaxLength)]
  [EmailAddress]
  public string EmailAddress { get; set; }


  [MaxLength(255)]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  [IgnoreDataMember]
  public string? TwoFactorKey { get; set; }

  /// <summary>
  ///   0: None
  ///   1: Email
  ///   2: Phone
  ///   3: Authy
  /// </summary>
  public byte TwoFactorType { get; set; }

  [JsonConverter(typeof(StringEnumConverter))]
  [NotMapped]
  public TwoFactorType TwoFactor {
    get => (TwoFactorType)TwoFactorType;
    set => TwoFactorType = (byte)value;
  }


  public DateTime? DeletedDate { get; set; }

  public bool IsDeleted => DeletedDate.HasValue;

  public int RoleId { get; set; }


  //virtual
  public Role Role { get; set; } = null!;
  public virtual HashSet<AdminLog> AdminLogs { get; set; }


  public static AdminDto ToDto(Admin admin) {
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
      RegisterDate = admin.RegisterDate
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
      DeletedDate = adminDto.DeletedDate,
      TwoFactor = (TwoFactorType)adminDto.TwoFactorType
    };
  }
  public static Admin FromDto(AddAdminRequest request) {
    return new Admin {
      RegisterDate = DateTime.Now,
      DeletedDate = null,
      EmailAddress = request.EmailAddress,
      TwoFactorType = 0,
      RoleId = request.RoleId,
      Password = request.Password.ToEncryptedText(),
      TwoFactor = Shared.Constants.TwoFactorType.None,
      
    };
  }

}