using ECom.Shared.Attributes;
using ECom.Shared.Entities;
using ECom.Shared.Resources;

namespace ECom.Shared.DTOs;

public class RoleDto
{
  public RoleDto() {
    
  }
  public RoleDto(string id, IEnumerable<AdminPermission> permissions) {
    Id = id;
    Permissions = permissions.ToList();
  }

  public RoleDto(string id, IEnumerable<PermissionRole> permissions) {
    Id = id;
    Permissions = permissions.Select(x => x.Permission).ToList();
  }

  public RoleDto(Role role) {
    Id = role.Id;
    Permissions = role.PermissionRoles.Select(x => x.Permission).ToList();
  }
  [Display(ResourceType = typeof(LocalizedResource), Name = Entities.Role.LocKey)]
  [Required]
  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  [AllowedChars(Chars = ValidationSettings.Alphabet)]
  public string Id{ get; set; }

  [Display(ResourceType = typeof(LocalizedResource), Name = "permission")]
  [EnsureOneElement(Name = "permission")]
  public List<AdminPermission> Permissions { get; set; }


}