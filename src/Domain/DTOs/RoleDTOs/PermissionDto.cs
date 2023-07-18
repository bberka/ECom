namespace ECom.Domain.DTOs.RoleDTOs;

public class PermissionDto
{
  public PermissionDto() {
    
  }

  public PermissionDto(Permission permission) {
    Id = permission.Id;
    Name = permission.Name;
    Memo = permission.Memo;
    IsValid = permission.IsValid;
  }
  public int Id { get; set; }
  public string Name { get; set; }
  public string? Memo { get; set; }
  public bool IsValid { get; set; }

}