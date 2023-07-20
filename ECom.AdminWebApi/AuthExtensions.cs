using ECom.Domain.Exceptions;

namespace ECom.AdminWebApi;

public static class AuthExtensions
{
  public static int GetAdminId(this HttpContext context) {
    if (context.User.Identity?.IsAuthenticated != true) throw new NotAuthorizedException(AuthType.Admin);
    var isAdmin = context.User.Claims.Any(x => x.Type == "AdminOnly");
    if (!isAdmin) throw new NotAuthorizedException(AuthType.Admin);
    var admin = context.User.FindFirst("Id")?.Value;
    if (admin is null) throw new NotAuthorizedException(AuthType.Admin);
    return admin.ConvertTo<int>();
  }

  public static bool IsAdminAuthenticated(this HttpContext context) {
    try {
      _ = context.GetAdminId();
      return true;
    }
    catch (Exception) {
      return false;
    }
  }

  public static string? GetClaim(this HttpContext context, string key) {
    return context.User.FindFirst(key)?.Value;
  }

  public static T GetClaim<T>(this HttpContext context, string key) {
    return context.User.FindFirst(key).Value.ConvertTo<T>();
  }

  public static AdminDto GetAdmin(this HttpContext context) {
    try {
      var claims = context.User.Identities.FirstOrDefault()?.Claims.AsDictionary();
      var user = claims?.ToObject<AdminDto>();
      if (user is null) throw new NotAuthorizedException(AuthType.Admin);
      return user;
    }
    catch (Exception ex) {
      throw new NotAuthorizedException(AuthType.User);
    }
  }
}