using EasMe.Extensions;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ECom.Domain.Extensions
{
	public static class AuthExtensions
	{
		public static int GetUserId(this ClaimsPrincipal principal)
		{
			var userIdString = principal.FindFirst("Id")?.Value;
			var userId = userIdString.StringConversion<int>();
#if DEBUG
			if (userId == 0) throw new NotAuthorizedException(AuthType.User);
#endif
			return userId;
		}
		public static User GetUser(this HttpContext context)
		{
			var user = context.Session.GetString("user")?.FromJsonString<User>();
			if (user is null) throw new NotAuthorizedException(AuthType.User);
			return user;
		}
		public static void SetUser(this HttpContext context,User user)
		{
			if(user is null) throw new InvalidDataException();
			context.Session.SetString("user",user.ToJsonString());
		}
		public static Admin GetAdmin(this HttpContext context)
		{
			var user = context.Session.GetString("admin")?.FromJsonString<Admin>();
			if (user is null) throw new NotAuthorizedException(AuthType.User);
			return user;
		}
		public static bool IsUserAuthenticated(this HttpContext context)
		{
			try
			{
				_ = context.GetUser();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public static bool IsAdminAuthenticated(this HttpContext context)
		{
			try
			{
				_ = context.GetAdmin();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public static void SetAdmin(this HttpContext context, Admin admin)
		{
			if (admin is null) throw new InvalidDataException();
			context.Session.SetString("admin", admin.ToJsonString());
		}
	}
}
