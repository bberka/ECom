namespace ECom.Foundation.DTOs.Request;

public class Request_Password_ResetByToken
{
  public string Token { get; set; }
  public string Password { get; set; }
  public string RepeatPassword { get; set; }
}