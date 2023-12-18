using ECom.Foundation.Entities;
using ECom.Foundation.Enum;

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
  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  // [AllowedChars(Chars = ConstantContainer.Alphabet)]
  public string Id { get; set; }

  // [EnsureOneElement(Name = "permissionType")]
  public List<AdminPermissionType> Permissions { get; set; }
}