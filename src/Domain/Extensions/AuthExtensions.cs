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
using System.Net.Mail;
using ECom.Domain.DTOs.Response;

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

		public static string? GetClaim(this HttpContext context,string key)
		{
			return context.User.FindFirst(key)?.Value;
		}
        public static T GetClaim<T>(this HttpContext context, string key)
        {
            return context.User.FindFirst(key).Value.StringConversion<T>();
        }
        //      public static Admin GetAdmin(this HttpContext context)
        //{
        //	try
        //	{
        //		var EasdmailAddress = context.GetClaim("EmailAddress");
        //		return new Admin
        //		{
        //			Id = context.GetAdminId(),
        //			EmailAddress = context.GetClaim("EmailAddress"),
        //			FailedPasswordCount = context.GetClaim<byte>("FailedPasswordCount"),
        //			IsTestAccount = context.GetClaim<bool>("IsTestAccount"),
        //			IsValid = context.GetClaim<bool>("IsValid"),
        //			LastLoginDate = context.GetClaim<DateTime>("LastLoginDate"),
        //			LastLoginIp = context.GetClaim("LastLoginIp"),
        //			LastLoginUserAgent = context.GetClaim("LastLoginUserAgent"),
        //			PasswordLastUpdateDate = context.GetClaim<DateTime>("PasswordLastUpdateDate"),
        //			RegisterDate = context.GetClaim<DateTime>("RegisterDate"),
        //			TotalLoginCount = context.GetClaim<int>("TotalLoginCount"),
        //			RoleId = context.GetClaim<int>("RoleId"),
        //			TwoFactorType = context.GetClaim<byte>("TwoFactorType"),
        //			//Role = context.GetClaim("Role").FromJsonString<Role>(),
        //			//Permissions = context.GetClaim("Permissions").FromJsonString<Permission[]>().ToList(),

        //		};
        //          }
        //          catch (Exception ex)
        //	{

        //		throw new NotAuthorizedException(AuthType.Admin);
        //	}
        //      }
        public static AdminDto GetAdmin(this HttpContext context)
        {
            try
            {
                var claims = context.User.Identities.FirstOrDefault()?.Claims.AsDictionary();
                var user = claims?.ToObject<AdminDto>();
                if (user is null) throw new NotAuthorizedException(AuthType.Admin);
                return user;
            }
            catch (Exception ex)
            {

                throw new NotAuthorizedException(AuthType.User);
            }
        }
        public static UserDto GetUser(this HttpContext context)
        {
            try
            {
                var claims = context.User.Identities.FirstOrDefault()?.Claims.AsDictionary();
				var user = claims?.ToObject<UserDto>();
				if(user is null) throw new NotAuthorizedException(AuthType.User);
                return user;
            }
            catch (Exception ex)
            {

                throw new NotAuthorizedException(AuthType.User);
            }
        }

    }
}
