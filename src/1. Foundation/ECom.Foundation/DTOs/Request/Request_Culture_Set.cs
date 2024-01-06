using Microsoft.AspNetCore.Mvc;

namespace ECom.Foundation.DTOs.Request;

public class Request_Culture_Set
{
  [MaxLength(6)]
  [MinLength(2)]
  [FromQuery]
  public string Culture { get; set; } = "en_us-US";

  [FromQuery]
  public string RedirectUri { get; set; }
}