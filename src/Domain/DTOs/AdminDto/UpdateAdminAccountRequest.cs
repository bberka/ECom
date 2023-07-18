namespace ECom.Domain.DTOs.AdminDto;

public class UpdateAdminAccountRequest : BaseAuthenticatedRequest
{
  public int Id { get; set; }
  public string EmailAddress { get; set; }

  public string? Password { get; set; }
  public bool UpdatePassword { get; set; } = false;

  public int RoleId { get; set; }
}