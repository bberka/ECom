using ECom.Shared.Entities;

namespace ECom.Shared.DTOs;

public class AddRoleRequest
{
  public string RoleName{ get; set; } 
  public List<string> Permissions { get; set; } = new List<string>();
}