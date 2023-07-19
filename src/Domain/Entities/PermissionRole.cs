namespace ECom.Domain.Entities;

[Table("PermissionRoles", Schema = "ECOperation")]
public class PermissionRole : IEntity
{
  public int RoleId { get; set; }
  public int PermissionId { get; set; }
  public Role Role { get; set; }
  public Permission Permission { get; set; }

  
}