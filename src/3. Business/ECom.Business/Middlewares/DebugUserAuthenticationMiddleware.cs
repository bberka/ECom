using ECom.Foundation.Static;

namespace ECom.Business.Middlewares;

public class DebugUserAuthenticationMiddleware
{
  private readonly RequestDelegate _next;
  private readonly IUserJwtAuthenticator _userJwtAuthenticator;
  private readonly IUserAccountService _userService;

  public DebugUserAuthenticationMiddleware(
    RequestDelegate next,
    IUserJwtAuthenticator userJwtAuthenticator,
    IUserAccountService userService) {
    _next = next;
    _userJwtAuthenticator = userJwtAuthenticator;
    _userService = userService;
  }

  public async Task InvokeAsync(HttpContext context) {
    if (!StaticValues.IS_DEVELOPMENT) await _next(context);

    //var hasBearer = context.Request.Headers.TryGetValue("Authorization", out var bearer);
    //if (!hasBearer) {
    //  var hasTokenInSession = context.Session.TryGetValue("user_debug_token", out var tokenInSession);
    //  if (!hasTokenInSession) {
    //    var adminResult = _userService.GetUser(1);
    //    if (adminResult.Status) {
    //      var tokenResult = _userJwtAuthenticator.Authenticate(new LoginRequest {
    //        Password = adminResult.Value.Password,
    //        EmailAddress = adminResult.Value.EmailAddress,
    //        IsHashed = true
    //      });
    //      if (tokenResult.Status) {
    //        var token = tokenResult.Value!;
    //        context.Response.Headers.Add("Authorization", $"Bearer {tokenResult.Value?.Token.Token}");
    //        context.Session.SetString("user_debug_token", token.Token.Token);
    //      }
    //    }
    //  }
    //  else {
    //    context.Request.Headers.Add("Authorization", $"Bearer {tokenInSession}");
    //  }
    //}
  }
}