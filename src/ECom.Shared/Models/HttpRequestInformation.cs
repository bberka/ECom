namespace ECom.Shared.Models;

public class HttpRequestInformation
{
  public string IpAddress {
    get {
      if (XRealIpAddress != null) return XRealIpAddress;
      if (CFConnectingIpAddress != null) return CFConnectingIpAddress;
      return RemoteIpAddress;
    }
  }

  public string RemoteIpAddress { get; set; } = string.Empty;
  public string? XRealIpAddress { get; set; }
  public string? CFConnectingIpAddress { get; set; }
  public string? UserAgent { get; set; }
}