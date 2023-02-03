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
		public static int GetUserId(this ClaimsPrincipal principal)
		{
			var userIdString = principal.FindFirst("Id")?.Value;
			var userId = userIdString.StringConversion<int>();
#if DEBUG
			if (userId == 0) throw new NotAuthorizedException();
#endif
			return userId;
		}

	}
}
