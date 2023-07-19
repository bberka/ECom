namespace ECom.Shared.DTOs;

public class LoginRequest
{
  public string EmailAddress { get; set; }
  public string Password { get; set; }
  public bool IsHashed { get; set; } = false;
}