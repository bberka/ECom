
namespace ECom.Shared.DTOs.RoleDto;

public class PermissionDto
{


  public int Id { get; set; }
  public string Name { get; set; }
  public string? Memo { get; set; }
  public bool IsValid { get; set; }
}