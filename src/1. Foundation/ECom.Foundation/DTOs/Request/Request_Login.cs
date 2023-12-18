namespace ECom.Foundation.DTOs.Request;

public class Request_Login
{
  [EmailAddress]
  [Required]

  public string EmailAddress { get; set; }

  [Required]
  public string Password { get; set; }

  public bool RememberMe { get; set; }
}