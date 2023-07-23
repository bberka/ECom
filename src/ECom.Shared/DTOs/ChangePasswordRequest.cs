namespace ECom.Shared.DTOs;

public class ChangePasswordRequest : BaseAuthenticatedRequest
{
  public string OldPassword { get; set; } = null!;
  public string NewPassword { get; set; } = null!;
  public string NewPasswordConfirm { get; set; } = null!;
}