namespace ECom.Shared.DTOs;

public class UpdateAdminAccountRequest : BaseAuthenticatedRequest
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; } = null!;

    [Required]
    public string RoleId { get; set; }

    public string? Password { get; set; }

    [Required]
    public bool UpdatePassword { get; set; } = false;
}