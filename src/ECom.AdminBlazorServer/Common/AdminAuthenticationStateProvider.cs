using System.Globalization;
using System.Security.Claims;
using AspNetCore.Authorization.Extender;
using ECom.Domain.Abstract;
using ECom.Shared.DTOs.AdminDto;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Serilog;

namespace ECom.AdminBlazorServer.Common;



public class AdminAuthenticationStateProvider : AuthenticationStateProvider, IAdminAuthenticationStateProvider
{
  private const string AdminLoginKey = "admin-login";
  private const string AdminAuthType = "admin-auth";

  private static readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());


  private readonly ProtectedSessionStorage _protectedSessionStorage;

  public AdminAuthenticationStateProvider(ProtectedSessionStorage protectedSessionStorage) {
    _protectedSessionStorage = protectedSessionStorage;
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

  public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
    //var identity = _anonymous.Identity as ClaimsIdentity;
    try {
      var login = await _protectedSessionStorage.GetAsync<AdminDto>(AdminLoginKey);
      var session = login.Success ? login.Value : null;
      if (session == null) return new AuthenticationState(_anonymous);
      var principal = CreatePrincipalFromLoginResponse(session);
      return await Task.FromResult(new AuthenticationState(principal));
    }
    catch (Exception ex) {
      Log.Error(ex, "Error getting authentication state");
      return new AuthenticationState(_anonymous);
    }
  }

  public async Task Logout() {
    await _protectedSessionStorage.DeleteAsync(AdminLoginKey);
    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
  }

  public async Task Login(AdminDto admin) {
    if (admin == null) throw new ArgumentNullException(nameof(admin));
    await _protectedSessionStorage.SetAsync(AdminLoginKey, admin);
    var claimsPrincipal = CreatePrincipalFromLoginResponse(admin);
    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
  }

  private static ClaimsPrincipal CreatePrincipalFromLoginResponse(AdminDto admin) {
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