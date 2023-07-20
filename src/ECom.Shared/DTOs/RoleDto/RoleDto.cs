namespace ECom.Shared.DTOs.RoleDto;

public class RoleDto
{
  public int Id { get; set; }

  public string Name { get; set; }

  public bool IsValid { get; set; } = true;

  public List<PermissionDto> Permissions { get; set; } = new();
}