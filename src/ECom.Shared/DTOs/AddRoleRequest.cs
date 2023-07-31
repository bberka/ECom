using ECom.Shared.Attributes;
using ECom.Shared.Entities;
using ECom.Shared.Resources;

namespace ECom.Shared.DTOs;

public class AddRoleRequest
{

  [Display(ResourceType = typeof(LocalizedResource), Name = "role_name")]
  [Required]
  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  public string RoleName{ get; set; }

  [Display(ResourceType = typeof(LocalizedResource), Name = "permissions")]
  [EnsureOneElement(Name = "permission")]
  public List<string> Permissions { get; set; } = new();
}