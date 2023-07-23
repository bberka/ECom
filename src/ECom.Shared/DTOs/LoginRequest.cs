namespace ECom.Shared.DTOs;

public class LoginRequest
{
  [EmailAddress]
  public string EmailAddress { get; set; }

  [Required]
  public string Password { get; set; }

  public bool IsHashed { get; set; } = false;
}