using ECom.Shared.Models;
using Microsoft.AspNetCore.Http;

namespace ECom.Domain.Extensions;

public static class HttpContextExtensions
{
  public static HttpRequestInformation? GetNecessaryRequestData(this HttpContext? ctx) {
    var request = ctx?.Request;
    if (request == null) return null;
    var remoteIpAddress = request.HttpContext.Connection.RemoteIpAddress.ToString();
    var xrealIpAddress = request.Headers["X-Real-Ip"].ToString();
    var cfConnectingIpAddress = request.Headers["CF-Connecting-Ip"].ToString();
    var userAgent = request.Headers["User-Agent"].ToString();
    return new HttpRequestInformation {
      RemoteIpAddress = remoteIpAddress,
      CFConnectingIpAddress = cfConnectingIpAddress,
      UserAgent = userAgent,
      XRealIpAddress = xrealIpAddress
    };
  }

  public static HttpRequestInformation? GetNecessaryRequestData(this HttpRequest? request) {
    if (request == null) return null;
    var remoteIpAddress = request.HttpContext.Connection.RemoteIpAddress.ToString();
    var xrealIpAddress = request.Headers["X-Real-Ip"].ToString();
    var cfConnectingIpAddress = request.Headers["CF-Connecting-Ip"].ToString();
    var userAgent = request.Headers["User-Agent"].ToString();
    return new HttpRequestInformation {
      RemoteIpAddress = remoteIpAddress,
      CFConnectingIpAddress = cfConnectingIpAddress,
      UserAgent = userAgent,
      XRealIpAddress = xrealIpAddress
    };
  }


}