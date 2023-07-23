using System.Collections.Concurrent;
using System.Security.Claims;
using Bers.Blazor.Ext.Javascript;
using EasMe;
using ECom.Shared;
using ECom.Shared.DTOs.AdminDto;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;

namespace ECom.AdminBlazorServer.Common;

public class AdminAuthenticationStateProvider : RevalidatingServerAuthenticationStateProvider
{
  private const int CookieExpireMinutes = 1440;
  private static readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());
  private readonly AuthenticationService _authenticationService;

  private readonly IJsCookieUtil _cookieUtil;

  public AdminAuthenticationStateProvider(ILoggerFactory loggerFactory,
    IJsCookieUtil cookieUtil,
    AuthenticationService authenticationService
  ) : base(loggerFactory) {
    _cookieUtil = cookieUtil;
    _authenticationService = authenticationService;
    _authenticationService.UserChanged += newUser => {
      NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(newUser)));
    };
  }

  private static ConcurrentDictionary<string, AdminLoginSession> Sessions { get; } = new();
  protected override TimeSpan RevalidationInterval { get; } = TimeSpan.FromSeconds(5);


  protected override async Task<bool> ValidateAuthenticationStateAsync(AuthenticationState authenticationState,
    CancellationToken cancellationToken) {
    var authState = await GetAuthenticationStateAsync();
    return authState.IsAuthenticated();
  }


  public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
    //var identity = _anonymous.Identity as ClaimsIdentity;
    try {
      var sessionId = await _cookieUtil.GetValue("admin-auth");
      if (string.IsNullOrEmpty(sessionId)) return await Task.FromResult(new AuthenticationState(_anonymous));
      Sessions.TryGetValue(sessionId, out var adminSession);
      if (adminSession is null) {
        _authenticationService.CurrentUser = _anonymous;
        return await Task.FromResult(new AuthenticationState(_authenticationService.CurrentUser));
      }

      var isExpired = adminSession.ExpireTime < DateTime.Now;
      if (isExpired) {
        Sessions.TryRemove(sessionId, out _);
        _authenticationService.CurrentUser = _anonymous;
        return await Task.FromResult(new AuthenticationState(_anonymous));
      }

      var principal = adminSession.Admin.CreatePrincipal();
      _authenticationService.CurrentUser = principal;
      return await Task.FromResult(new AuthenticationState(_authenticationService.CurrentUser));
    }
    catch (Exception ex) {
      //Log.Error(ex, "Error getting authentication state");
      _authenticationService.CurrentUser = _anonymous;
      return await Task.FromResult(new AuthenticationState(_anonymous));
    }
  }

  public async Task Logout() {
    var sessionId = await _cookieUtil.GetValue("admin-auth");
    if (!string.IsNullOrEmpty(sessionId)) {
      await _cookieUtil.RemoveValue("admin-auth");
      Sessions.TryRemove(sessionId, out _);
    }

    _authenticationService.CurrentUser = _anonymous;
  }

  private static string GetUniqueSessionId() {
    var sessionId = EasGenerate.RandomString(2048);
    return Sessions.ContainsKey(sessionId) ? GetUniqueSessionId() : sessionId;
  }

  public async Task<CustomResult> Login(AdminDto admin) {
    if (admin == null) throw new ArgumentNullException(nameof(admin));
    if (_authenticationService.CurrentUser.Identity?.IsAuthenticated == true) await Logout();
    var expire = TimeSpan.FromMinutes(CookieExpireMinutes);
    var resp = AdminLoginSession.Create(admin, expire);
    var sessionId = GetUniqueSessionId();
    Sessions.TryAdd(sessionId, resp);
    var claimsPrincipal = admin.CreatePrincipal();
    await _cookieUtil.SetValue("admin-auth", sessionId, expire);
    _authenticationService.CurrentUser = claimsPrincipal;
    return DomainResult.Ok(nameof(Login));
  }
}