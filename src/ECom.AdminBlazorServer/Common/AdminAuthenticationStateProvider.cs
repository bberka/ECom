using System.Globalization;
using System.Security.Claims;
using AspNetCore.Authorization.Extender;
using Bers.Blazor.Ext.Javascript;
using ECom.Domain.Abstract;
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

  private static readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());


  private readonly ProtectedSessionStorage _protectedSessionStorage;
  private readonly IJsSessionUtil _jsSessionUtil;


  public AdminAuthenticationStateProvider(ILoggerFactory loggerFactory, 
    LoginStateCacheProvider cacheProvider,
    ProtectedSessionStorage protectedSessionStorage,
    IJsSessionUtil jsSessionUtil) : base(loggerFactory) {
    _cacheProvider = cacheProvider;
    _protectedSessionStorage = protectedSessionStorage;
    _jsSessionUtil = jsSessionUtil;
  }

  //public async Task<bool> IsAuthenticated() {
  //  var authState = await GetAuthenticationStateAsync();
  //  return authState?.User?.Identity?.IsAuthenticated == true;
  //}

  //public async Task<AdminDto> GetAdmin() {
  //  var authState = await GetAuthenticationStateAsync();
  //  return authState.User.GetAdmin();
  //  //var adminDto = new AdminDto();
  //  //adminDto.Id = Guid.Parse(authState?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
  //  //adminDto.EmailAddress = authState?.User?.FindFirstValue(ClaimTypes.Email) ?? "";
  //  //adminDto.RoleId = authState?.User?.FindFirstValue(ClaimTypes.Role) ?? "";
  //  //adminDto.Permissions =
  //  //  authState?.User?.FindFirstValue(ExtClaimTypes.EndPointPermissions)?.Split(',') ?? new string[0];
  //  //adminDto.Password = authState?.User?.FindFirstValue(ClaimTypes.Hash) ?? "";
  //  //adminDto.RegisterDate =
  //  //  DateTime.Parse(authState?.User?.FindFirstValue("RegisterDate") ?? "", CultureInfo.InvariantCulture);
  //  //adminDto.TwoFactorType = Enum.Parse<TwoFactorType>(authState?.User?.FindFirstValue("TwoFactorType") ?? "0");
  //  //return adminDto;
  //}
  private readonly LoginStateCacheProvider _cacheProvider;


  
  protected override async Task<bool> ValidateAuthenticationStateAsync(AuthenticationState authenticationState, CancellationToken cancellationToken) {
    var user = authenticationState.User;
    var isAuthenticated = user.Identity?.IsAuthenticated ?? false;
    if (!isAuthenticated) return false;
    var sid = user.GetAdminId().ToString();
    var loginState = _cacheProvider.Validate(sid);
    return loginState;

  }

  //Default is 10 seconds according to microsoft docs
  protected override TimeSpan RevalidationInterval { get; } = TimeSpan.FromSeconds(5);
  public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
    //var identity = _anonymous.Identity as ClaimsIdentity;
    try {
      var login = await _protectedSessionStorage.GetAsync<AdminDto>(AdminLoginKey);
      var session = login.Success ? login.Value : null;
      if (session == null) {
        return new AuthenticationState(_anonymous);
      }
      var isValid = _cacheProvider.Validate(session.Id.ToString());
      if (!isValid) {

        return new AuthenticationState(_anonymous);
      }
      var principal = CreatePrincipalFromLoginResponse(session);
      var state = new AuthenticationState(principal);
      return await Task.FromResult(state);
    }
    catch (Exception ex) {
      //Log.Error(ex, "Error getting authentication state");
      return new AuthenticationState(_anonymous);
    }
  }

  public async Task Logout() {
    var authState = await GetAuthenticationStateAsync();
    var sid = authState.User.GetAdminId().ToString();
    _cacheProvider.Remove(sid);
    //await _protectedSessionStorage.DeleteAsync(AdminLoginKey);
    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
    await _jsSessionUtil.RemoveValue(AdminLoginKey);
  }

  public async Task Login(AdminDto admin) {
    if (admin == null) throw new ArgumentNullException(nameof(admin));
    var authState = await GetAuthenticationStateAsync();
    if (authState.User.Identity?.IsAuthenticated == true) {
      await Logout();
    }
    await _protectedSessionStorage.SetAsync(AdminLoginKey, admin);
    var claimsPrincipal = CreatePrincipalFromLoginResponse(admin);
    var sid = claimsPrincipal.GetAdminId().ToString();
    _cacheProvider.Add(sid);
    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
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

  //protected override async Task<bool> ValidateAuthenticationStateAsync(AuthenticationState authenticationState, CancellationToken cancellationToken) {
  //  var login = await _protectedSessionStorage.GetAsync<AdminDto>(AdminLoginKey);
  //  var session = login.Success ? login.Value : null;
  //  if (session == null) return false;
  //  var principal = CreatePrincipalFromLoginResponse(session);
  //  var newAuthState = new AuthenticationState(principal);
  //  var currentAuthState = await GetAuthenticationStateAsync();
  //  var isAuthenticated = currentAuthState.User.Identity.IsAuthenticated;
  //  if (isAuthenticated != newAuthState.User.Identity.IsAuthenticated) {
  //    NotifyAuthenticationStateChanged(Task.FromResult(newAuthState));
  //  }
  //  return newAuthState.User.Identity.IsAuthenticated;
    
  //}

  //protected override TimeSpan RevalidationInterval { get; }
}