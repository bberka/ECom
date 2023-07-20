namespace ECom.Domain.Entities;

[Table("Roles", Schema = "ECOperation")]
public class Role : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  [MinLength(ConstantMgr.NameMinLength)]
  [MaxLength(ConstantMgr.NameMaxLength)]
  public string Name { get; set; }

  public bool IsValid { get; set; } = true;

  //Virtual
  public IEnumerable<PermissionRole> PermissionRoles { get; set; } = new List<PermissionRole>();

  public static RoleDto ToDto(Role role) {
    return new RoleDto {
      Id = role.Id,
      Name = role.Name,
      IsValid = role.IsValid,
      Permissions = role.PermissionRoles.Select(pr => Permission.ToDto(pr.Permission)).ToList()
    };
  }
}