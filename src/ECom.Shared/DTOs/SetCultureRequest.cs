using Microsoft.AspNetCore.Mvc;

namespace ECom.Shared.DTOs;

public class SetCultureRequest
{
  [MaxLength(6)]
  [MinLength(2)]
  [FromQuery]
  public string Culture { get; set; } = "en-US";

  [FromQuery]
  public string RedirectUri { get; set; }
}