namespace ECom.Domain.Entities;

//[PrimaryKey(nameof(RoleId),nameof(PermissionId))]
public class PermissionRole : IEntity
{
  public int RoleId { get; set; }
  public int PermissionId { get; set; }
  public Role Role { get; set; }
  public Permission Permission { get; set; }
}