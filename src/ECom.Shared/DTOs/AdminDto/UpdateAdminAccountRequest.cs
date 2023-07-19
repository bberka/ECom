namespace ECom.Shared.DTOs.AdminDto;

public class UpdateAdminAccountRequest : BaseAuthenticatedRequest
{
  public int Id { get; set; }
  public string EmailAddress { get; set; } = null!;

  public string? Password { get; set; }
  public bool UpdatePassword { get; set; } = false;

  public int RoleId { get; set; }
}