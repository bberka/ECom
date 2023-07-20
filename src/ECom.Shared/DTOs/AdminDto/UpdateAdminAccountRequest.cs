namespace ECom.Shared.DTOs.AdminDto;

public class UpdateAdminAccountRequest : BaseAuthenticatedRequest
{
  [Required]
  [Range(0, int.MaxValue)]
  public int Id { get; set; }

  [Required]
  [EmailAddress]
  public string EmailAddress { get; set; } = null!;

  [Required]
  [Range(0, 255)]
  public int RoleId { get; set; }

  public string? Password { get; set; }

  [Required]
  public bool UpdatePassword { get; set; } = false;
}