namespace ECom.Domain.DTOs;

public class ChangePasswordRequest : BaseAuthenticatedRequest
{
  public string OldPassword { get; set; }
  public string EncryptedOldPassword => Convert.ToBase64String(OldPassword.MD5Hash());
  public string NewPassword { get; set; }
  public string NewPasswordConfirm { get; set; }
  public string EncryptedNewPassword => Convert.ToBase64String(NewPassword.MD5Hash());
}