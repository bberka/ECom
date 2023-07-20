namespace ECom.Shared.DTOs.AdminDto;

public class AddAdminRequest : BaseAuthenticatedRequest
{
  public string EmailAddress { get; set; }

  public string Password { get; set; }

  public int RoleId { get; set; }
}