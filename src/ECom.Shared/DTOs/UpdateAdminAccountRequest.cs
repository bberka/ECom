using ECom.Shared.Resources;

namespace ECom.Shared.DTOs;

public class UpdateAdminAccountRequest : BaseAuthenticatedRequest
{
    [Required]
    public Guid Id { get; set; }

    [EmailAddress]
    [Required]
    [Display(ResourceType = typeof(LocalizedResource), Name = "email_address")]
    [MaxLength(ValidationSettings.MaxEmailLength)]
    public string EmailAddress { get; set; }

    [Display(ResourceType = typeof(LocalizedResource), Name = "role")]
    [Required]
    [MinLength(ValidationSettings.MinNameLength)]
    [MaxLength(ValidationSettings.MaxNameLength)]
    public string RoleId { get; set; }

}