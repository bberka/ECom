using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Models
{
	public class HttpRequestData
	{
		public string IpAddress 
		{
			get
			{
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
}
