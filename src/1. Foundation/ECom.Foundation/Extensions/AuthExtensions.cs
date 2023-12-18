using ECom.Foundation.DTOs;
using ECom.Foundation.Enum;
using ECom.Foundation.Exceptions;

namespace ECom.Foundation.Extensions;

public static class AuthExtensions
{
  public static Guid GetAuthId(this HttpContext context) {
    if (context == null) throw new NullReferenceException(nameof(context));
    if (context.User == null) throw new NotAuthorizedException(AuthType.None);
    if (context.User.Identity == null) throw new NotAuthorizedException(AuthType.None);
    if (context.User.Identity?.IsAuthenticated != true) throw new NotAuthorizedException(AuthType.None);
    var id = context.User.FindFirst("Id")?.Value;
    if (id is null) throw new NotAuthorizedException(AuthType.None);
    return id.ConvertTo<Guid>();
    // throw new NotAuthorizedException(AuthType.None);
  }

  public static Guid GetUserId(this HttpContext context) {
    context.EnsureUserAuthenticated();
    var id = context.User.FindFirst("Id")?.Value;
    if (id is null)
      throw new NotAuthorizedException(AuthType.User);
    return id.ConvertTo<Guid>();
  }

  public static Guid GetAdminId(this HttpContext context) {
    context.EnsureAdminAuthenticated();
    var id = context.User.FindFirst("Id")?.Value;
    if (id is null)
      throw new NotAuthorizedException(AuthType.Admin);
    return id.ConvertTo<Guid>();
  }


  public static void EnsureUserAuthenticated(this HttpContext context) {
    if (context == null) throw new NullReferenceException(nameof(context));
    if (context.User == null) throw new NotAuthorizedException(AuthType.None);
    if (context.User.Identity == null) throw new NotAuthorizedException(AuthType.None);
    if (context.User.Identity?.IsAuthenticated != true) throw new NotAuthorizedException(AuthType.None);
    var isUser = context.HasClaim(EComClaimTypes.UserClaimType);
    if (!isUser) throw new NotAuthorizedException(AuthType.User);
  }

  public static void EnsureAdminAuthenticated(this HttpContext context) {
    if (context == null) throw new NullReferenceException(nameof(context));
    if (context.User == null) throw new NotAuthorizedException(AuthType.None);
    if (context.User.Identity == null) throw new NotAuthorizedException(AuthType.None);
    if (context.User.Identity?.IsAuthenticated != true) throw new NotAuthorizedException(AuthType.None);
    var isAdmin = context.HasClaim(EComClaimTypes.AdminClaimType);
    if (!isAdmin) throw new NotAuthorizedException(AuthType.Admin);
  }


  public static bool IsAuthenticated(this HttpContext context) {
    try {
      _ = context.GetAuthId();
      return true;
    }
    catch (Exception) {
      return false;
    }
  }

  public static string? GetClaim(this HttpContext context, string key) {
    return context.User.FindFirst(key)?.Value;
  }

  public static T? GetClaim<T>(this HttpContext context, string key) {
    var claim = context.User.FindFirst(key);
    if (claim is null) return default;
    return claim.Value.ConvertTo<T>();
  }

  public static bool HasClaim(this HttpContext context, string key) {
    return context.User.HasClaim(x => x.Type == key);
  }


  public static UserDto GetUser(this HttpContext context) {
    try {
      var isAuthenticated = context.IsAuthenticated();
      var claims = context.User.Identities.FirstOrDefault()?.Claims.AsDictionary();
      var userDto = new UserDto();
      var user = claims?.ToObject<UserDto>();
      if (user is null) throw new NotAuthorizedException(AuthType.User);
      return user;
    }
    catch (Exception ex) {
      throw new NotAuthorizedException(AuthType.User);
    }
  }

  public static AdminDto GetAdmin(this HttpContext context) {
    try {
      var claims = context.User.Identities.FirstOrDefault()?.Claims.AsDictionary();
      var admin = claims?.ToObject<AdminDto>();
      if (admin is null) throw new NotAuthorizedException(AuthType.Admin);
      return admin;
    }
    catch (Exception ex) {
      throw new NotAuthorizedException(AuthType.Admin);
    }
  }
}