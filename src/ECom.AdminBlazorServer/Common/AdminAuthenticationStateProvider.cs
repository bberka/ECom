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
  private const int CookieExpireMinutes = 1440;
  private static readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

  private readonly IJsCookieUtil _cookieUtil;
  private readonly AuthenticationService _authenticationService;
  private static ConcurrentDictionary<string, AdminLoginSession> Sessions { get; set; } = new();
  protected override TimeSpan RevalidationInterval { get; } = TimeSpan.FromSeconds(5);

  public AdminAuthenticationStateProvider(ILoggerFactory loggerFactory,
    IJsCookieUtil cookieUtil,
    AuthenticationService authenticationService
    ) : base(loggerFactory) {
    _cookieUtil = cookieUtil;
    _authenticationService = authenticationService;
    _authenticationService.UserChanged += (newUser) => {
      NotifyAuthenticationStateChanged(
        Task.FromResult(new AuthenticationState(newUser)));
    };
  }


  protected override async Task<bool> ValidateAuthenticationStateAsync(AuthenticationState authenticationState, CancellationToken cancellationToken) {
    var user = authenticationState.User;
    var isAuthenticated = user.Identity?.IsAuthenticated ?? false;
    if (!isAuthenticated) return false;
    var sessionId = await _cookieUtil.GetValue("admin-auth");
    if (string.IsNullOrEmpty(sessionId)) {
      _authenticationService.CurrentUser = _anonymous;
      return false;
    }
    Sessions.TryGetValue(sessionId, out var adminSession);
    if (adminSession is null) {
      _authenticationService.CurrentUser = _anonymous;
      return false;
    }
    var isExpired = adminSession.ExpireTime < DateTime.Now;
    if (isExpired) {
      Sessions.TryRemove(sessionId, out _);
      _authenticationService.CurrentUser = _anonymous;
      return false;
    }
    _authenticationService.CurrentUser = adminSession.Admin.CreatePrincipal();
    return true;
  }


  public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
    //var identity = _anonymous.Identity as ClaimsIdentity;
    try {
      var sessionId = await _cookieUtil.GetValue("admin-auth");
      if(string.IsNullOrEmpty(sessionId)) return await Task.FromResult(new AuthenticationState(_anonymous));
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
      var admin = adminSession.Admin;
      var principal = admin.CreatePrincipal();
      var state = new AuthenticationState(principal);
      _authenticationService.CurrentUser = principal;
      return await Task.FromResult(state);

    } catch (Exception ex) {
      //Log.Error(ex, "Error getting authentication state");
      _authenticationService.CurrentUser = _anonymous;
      return await Task.FromResult(new AuthenticationState(_anonymous));
    }
  }

  public async Task Logout() {
    var sessionId = await _cookieUtil.GetValue("admin-auth");
    if (!string.IsNullOrEmpty(sessionId) ) {
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
    var authState = await GetAuthenticationStateAsync();
    if (authState.User.Identity?.IsAuthenticated == true) {
      await Logout();
    }
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