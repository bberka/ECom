namespace ECom.Shared.DTOs;

public class ChangePasswordRequestDto : BaseAuthenticatedRequest
{
  public string OldPassword { get; set; } = null!;
  public string NewPassword { get; set; } = null!;
  public string NewPasswordConfirm { get; set; } = null!;
}