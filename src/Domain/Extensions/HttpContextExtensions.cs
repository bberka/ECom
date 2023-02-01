using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Extensions
{
	public static class HttpContextExtensions
	{
		public static HttpRequestData? GetNecessaryRequestData(this HttpContext? ctx)
		{
			var request = ctx?.Request;
			if (request == null) return null;
			var remoteIpAddress = request.HttpContext.Connection.RemoteIpAddress.ToString();
			var xrealIpAddress = request.Headers["X-Real-Ip"].ToString();
			var cfConnectingIpAddress = request.Headers["CF-Connecting-Ip"].ToString();
			var userAgent = request.Headers["User-Agent"].ToString();
			return new HttpRequestData
			{
				RemoteIpAddress = remoteIpAddress,
				CFConnectingIpAddress= cfConnectingIpAddress,	
				UserAgent = userAgent,	
				XRealIpAddress= xrealIpAddress,
			};
		}
		public static HttpRequestData? GetNecessaryRequestData(this HttpRequest? request)
		{
			if (request == null) return null;
			var remoteIpAddress = request.HttpContext.Connection.RemoteIpAddress.ToString();
			var xrealIpAddress = request.Headers["X-Real-Ip"].ToString();
			var cfConnectingIpAddress = request.Headers["CF-Connecting-Ip"].ToString();
			var userAgent = request.Headers["User-Agent"].ToString();
			return new HttpRequestData
			{
				RemoteIpAddress = remoteIpAddress,
				CFConnectingIpAddress = cfConnectingIpAddress,
				UserAgent = userAgent,
				XRealIpAddress = xrealIpAddress,
			};
		}
	}
}
