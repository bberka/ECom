using ECom.Foundation.Static;

namespace ECom.Foundation.DTOs.Request;

public class Request_PageWithCulture : Request_Page
{
  public CultureType Culture { get; set; }
}