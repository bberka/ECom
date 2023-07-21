using EasMe.EntityFrameworkCore;

namespace ECom.Domain.Entities;

[Table("PermissionRoles", Schema = "ECOperation")]
[PrimaryKey(nameof(RoleId),nameof(PermissionId))]
public class PermissionRole : IEntity
{
  public string RoleId { get; set; }
  public string PermissionId { get; set; }
  public virtual Role Role { get; set; }
  public virtual Permission Permission { get; set; }
}