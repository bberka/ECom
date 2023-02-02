using EasMe.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Extensions
{
	public static class AuthExtensions
	{
		public static uint GetUserId(this ClaimsPrincipal principal)
		{
			var userIdString = principal.FindFirst("Id")?.Value;
			var userId = userIdString.StringConversion<uint>();
#if DEBUG
			if (userId == 0) userId = 8;
#endif
			return userId;
		}

	}
}
