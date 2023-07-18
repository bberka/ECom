using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ECom.Domain.Entities;

[Table("Admins", Schema = "ECOperation")]
public class Admin : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  public DateTime RegisterDate { get; set; } = DateTime.Now;

  public bool IsValid { get; set; } = true;


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
  public byte TwoFactorType { get; set; } = 0;

  [JsonConverter(typeof(StringEnumConverter))]
  [NotMapped]
  public TwoFactorType TwoFactor {
    get => (TwoFactorType)TwoFactorType;
    set => TwoFactorType = (byte)value;
  } 


  public DateTime? DeletedDate { get; set; }

  public int RoleId { get; set; }


  //virtual
  public Role Role { get; set; } = null!;
  public virtual HashSet<AdminLog> AdminLogs { get; set; }
}