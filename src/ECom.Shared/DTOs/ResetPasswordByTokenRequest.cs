namespace ECom.Shared.DTOs;

public class ResetPasswordByTokenRequest : EmailTokenRequest
{
  public string Password { get; set; }
  public string RepeatPassword { get; set; }
}