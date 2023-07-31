using ECom.Shared.Resources;

namespace ECom.Shared.DTOs;

public class LoginRequest
{
  [EmailAddress]
  [Required]
  [Display(Name = "email_address", ResourceType = typeof(LocalizedResource))]

  public string EmailAddress { get; set; }

  [Required]
  [Display(Name = "password", ResourceType = typeof(LocalizedResource))]
  public string Password { get; set; }

  public bool IsHashed { get; set; } = false;
  public bool RememberMe { get; set; }
}