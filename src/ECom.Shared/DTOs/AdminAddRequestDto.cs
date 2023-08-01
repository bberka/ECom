using System.Runtime.InteropServices;
using ECom.Shared.Resources;

namespace ECom.Shared.DTOs;

public class AdminAddRequestDto : BaseAuthenticatedRequest
{
  [EmailAddress]
  [Required]
  [Display(ResourceType = typeof(LocalizedResource), Name = "email_address")]
  [MaxLength(ValidationSettings.MaxEmailLength)]
  public string EmailAddress { get; set; }


  [Display(ResourceType = typeof(LocalizedResource), Name = "password")]
  [Required]
  [MaxLength(ValidationSettings.MaxPasswordLength)]
  [MinLength(ValidationSettings.MinPasswordLength)]
  public string Password { get; set; }

  [Display(ResourceType = typeof(LocalizedResource), Name = "role")]
  [Required]
  [MinLength(ValidationSettings.MinNameLength)]
  [MaxLength(ValidationSettings.MaxNameLength)]
  public string RoleId { get; set; }
}