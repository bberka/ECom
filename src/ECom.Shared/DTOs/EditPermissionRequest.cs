using ECom.Shared.Attributes;
using ECom.Shared.Entities;

namespace ECom.Shared.DTOs;

public class EditPermissionRequest
{
  [Required]
  [EnsureOneElement(Name = "permission")]
  public List<string> Permissions { get; set; } = new();
}