namespace ECom.Domain.DTOs.RoleDTOs;

public class RoleDto
{
  public RoleDto(Role role) {
    Id = role.Id;
    Name = role.Name;
    IsValid = role.IsValid;
    Permissions = role.PermissionRoles.Select(pr => new PermissionDto(pr.Permission)).ToList();
  }

  public RoleDto() {
    
  }
  public int Id { get; set; }

  public string Name { get; set; }

  public bool IsValid { get; set; } = true;

  public List<PermissionDto> Permissions { get; set; } = new List<PermissionDto>();
}