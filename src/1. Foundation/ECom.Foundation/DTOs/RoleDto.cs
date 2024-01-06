using ECom.Foundation.Entities;
using ECom.Foundation.Static;

namespace ECom.Foundation.DTOs;

public class RoleDto
{
  public RoleDto() { }

  public RoleDto(string id, IEnumerable<AdminPermissionType> permissions) {
    Id = id;
    Permissions = permissions.ToList();
  }

  public RoleDto(string id, IEnumerable<PermissionRole> permissions) {
    Id = id;
    Permissions = permissions.Select(x => x.PermissionType).ToList();
  }

  public RoleDto(Role role) {
    Id = role.Id;
    Permissions = role.PermissionRoles.Select(x => x.PermissionType).ToList();
  }

  [Required]
  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  // [AllowedChars(Chars = StaticValues.ALPHABET)]
  public string Id { get; set; }

  // [EnsureOneElement(Name = "permissionType")]
  public List<AdminPermissionType> Permissions { get; set; }
}