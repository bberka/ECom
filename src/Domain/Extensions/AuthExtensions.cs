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
	
        public static int GetUserId(this HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated != true) throw new NotAuthorizedException(AuthType.User);
            var isUser = context.User.Claims.Any(x => x.Type == "UserOnly");
            if (!isUser) throw new NotAuthorizedException(AuthType.User);
            var user = context.User.FindFirst("Id")?.Value;
            if (user is null) throw new NotAuthorizedException(AuthType.User);
            return user.StringConversion<int>();
        }
        public static int GetAdminId(this HttpContext context)
        {
			if(context.User.Identity?.IsAuthenticated != true) throw new NotAuthorizedException(AuthType.Admin);
            var isAdmin = context.User.Claims.Any(x => x.Type == "AdminOnly");
			if (!isAdmin) throw new NotAuthorizedException(AuthType.Admin);
			var admin = context.User.FindFirst("Id")?.Value;
            if (admin is null) throw new NotAuthorizedException(AuthType.Admin);
            return admin.StringConversion<int>();
        }
		
		public static bool IsUserAuthenticated(this HttpContext context)
		{
			try
			{
				_ = context.GetUserId();
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
				_ = context.GetAdminId();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

        public static Admin GetAdmin(this HttpContext context)
        {
			try
			{
                var admin = context.User.ToModel<Admin>();
				return admin;
            }
            catch (Exception ex)
			{

				throw new NotAuthorizedException(AuthType.Admin);
			}
        }
        public static User GetUser(this HttpContext context)
        {
            try
            {
                var user = context.User.ToModel<User>();
                return user;
            }
            catch (Exception ex)
            {

                throw new NotAuthorizedException(AuthType.User);
            }
        }

    }
}
