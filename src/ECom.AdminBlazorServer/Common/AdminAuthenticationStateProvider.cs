using System.Collections.Concurrent;
using System.Globalization;
using System.Security.Claims;
using AspNetCore.Authorization.Extender;
using Bers.Blazor.Ext.Javascript;
using Blazored.SessionStorage;
using EasMe;
using ECom.Application.Services;
using ECom.Domain.Abstract;
using ECom.Shared;
using ECom.Shared.DTOs;
using ECom.Shared.DTOs.AdminDto;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Serilog;

namespace ECom.AdminBlazorServer.Common;



public class AdminAuthenticationStateProvider : RevalidatingServerAuthenticationStateProvider
{
  private const string AdminLoginKey = "admin-login";
  private const string AdminAuthType = "admin-auth";
  private const int CookieExpireMinutes = 1440;
  private static readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

  private readonly IJsCookieUtil _cookieUtil;
  private static ConcurrentDictionary<string, AdminLoginSession> Sessions { get; set; } = new();
  protected override TimeSpan RevalidationInterval { get; } = TimeSpan.FromSeconds(5);

  public AdminAuthenticationStateProvider(ILoggerFactory loggerFactory,
    IJsCookieUtil cookieUtil
    ) : base(loggerFactory) {
    _cookieUtil = cookieUtil;
  }


  protected override async Task<bool> ValidateAuthenticationStateAsync(AuthenticationState authenticationState, CancellationToken cancellationToken) {
    var user = authenticationState.User;
    var isAuthenticated = user.Identity?.IsAuthenticated ?? false;
    if (!isAuthenticated) return false;
    var sessionId = await _cookieUtil.GetValue(AdminLoginKey);
    if (string.IsNullOrEmpty(sessionId)) return false;
    Sessions.TryGetValue(sessionId, out var adminSession);
    if (adminSession is null) {
      return false;
    }
    var isExpired = adminSession.ExpireTime < DateTime.Now;
    if (isExpired) {
      Sessions.TryRemove(sessionId, out _);
      var aState = new AuthenticationState(_anonymous);
      NotifyAuthenticationStateChanged(Task.FromResult(aState));
      return false;
    }
    return true;
  }


  public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
    //var identity = _anonymous.Identity as ClaimsIdentity;
    try {
      var sessionId = await _cookieUtil.GetValue(AdminLoginKey);
      if(string.IsNullOrEmpty(sessionId)) return await Task.FromResult(new AuthenticationState(_anonymous));
      Sessions.TryGetValue(sessionId, out var adminSession);
      if (adminSession is null) {
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
        return await Task.FromResult(new AuthenticationState(_anonymous));
      }
      var isExpired = adminSession.ExpireTime < DateTime.Now;
      if (isExpired) {
        Sessions.TryRemove(sessionId, out _);
        var aState = new AuthenticationState(_anonymous);
        NotifyAuthenticationStateChanged(Task.FromResult(aState));
        return await Task.FromResult(new AuthenticationState(_anonymous));
      }
      var admin = adminSession.Admin;
      var principal = CreatePrincipalFromLoginResponse(admin);
      var state = new AuthenticationState(principal);
      return await Task.FromResult(state);
    } catch (Exception ex) {
      //Log.Error(ex, "Error getting authentication state");
      return await Task.FromResult(new AuthenticationState(_anonymous));
    }
  }

  public async Task Logout() {
    var sessionId = await _cookieUtil.GetValue(AdminLoginKey);
    if (!string.IsNullOrEmpty(sessionId) ) {
      await _cookieUtil.RemoveValue(AdminLoginKey);
      Sessions.TryRemove(sessionId, out _);
    }
    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
  }

  private static string GetUniqueSessionId() {
    var sessionId = EasGenerate.RandomString(2048);
    return Sessions.ContainsKey(sessionId) ? GetUniqueSessionId() : sessionId;
  }

  public async Task<CustomResult> Login(AdminDto admin) {
    if (admin == null) throw new ArgumentNullException(nameof(admin));
    var authState = await GetAuthenticationStateAsync();
    if (authState.User.Identity?.IsAuthenticated == true) {
      await Logout();
    }
    var expire = TimeSpan.FromMinutes(CookieExpireMinutes);
    var resp = AdminLoginSession.Create(admin, expire);
    var sessionId = GetUniqueSessionId();
    Sessions.TryAdd(sessionId, resp);
    var claimsPrincipal = CreatePrincipalFromLoginResponse(admin);
    await _cookieUtil.SetValue(AdminLoginKey, sessionId, expire);
    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    return DomainResult.Ok(nameof(Login));
  }

  public static ClaimsPrincipal CreatePrincipalFromLoginResponse(AdminDto admin) {
    var claims = new List<Claim> {
      //claims.Add(new Claim("AdminOnly", "true"));
      new(ClaimTypes.Role, admin.RoleId),
      new(ClaimTypes.NameIdentifier, admin.Id.ToString()),
      new(ClaimTypes.Name, admin.EmailAddress),
      new(ClaimTypes.Email, admin.EmailAddress),
      new("TwoFactorType", admin.TwoFactorType.ToString()),
      new("RegisterDate", admin.RegisterDate.ToString(CultureInfo.InvariantCulture)),
      new(ClaimTypes.Hash, admin.Password)
    };
    var permissions = admin.Permissions.ToList().CreatePermissionString();
    claims.Add(new Claim(ExtClaimTypes.EndPointPermissions, permissions));
    return new ClaimsPrincipal(new ClaimsIdentity(claims, AdminAuthType));
  }

}