using ECom.Domain.Exceptions;
using ECom.Shared.Constants;
using ECom.Shared.DTOs;

namespace ECom.WebApi;

public static class AuthExtensions
{
  public static Guid GetUserId(this HttpContext context) {
    if (context.User.Identity?.IsAuthenticated != true) throw new NotAuthorizedException(AuthType.User);
    var isUser = context.User.Claims.Any(x => x.Type == "UserOnly");
    if (!isUser) throw new NotAuthorizedException(AuthType.User);
    var user = context.User.FindFirst("Id")?.Value;
    if (user is null) throw new NotAuthorizedException(AuthType.User);
    return user.ConvertTo<Guid>();
  }


  public static bool IsUserAuthenticated(this HttpContext context) {
    try {
      _ = context.GetUserId();
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


  public static UserDto GetUser(this HttpContext context) {
    try {
      var claims = context.User.Identities.FirstOrDefault()?.Claims.AsDictionary();
      var user = claims?.ToObject<UserDto>();
      if (user is null) throw new NotAuthorizedException(AuthType.User);
      return user;
    }
    catch (Exception ex) {
      throw new NotAuthorizedException(AuthType.User);
    }
  }
}