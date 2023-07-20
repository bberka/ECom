using System.Globalization;
using System.Security.Claims;
using AspNetCore.Authorization.Extender;
using EasMe.Extensions;
using ECom.Domain.Entities;
using ECom.Shared.Constants;
using ECom.Shared.DTOs.AdminDto;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Serilog;

namespace ECom.AdminBlazorServer.Common;

public class AdminAuthenticationStateProvider : AuthenticationStateProvider
{
  private const string AdminLoginKey = "admin-login";
  private const string AdminAuthType = "admin-auth";


  private readonly ProtectedSessionStorage _protectedSessionStorage;

  private static readonly ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
  public AdminAuthenticationStateProvider(ProtectedSessionStorage protectedSessionStorage) {
    _protectedSessionStorage = protectedSessionStorage;
  }

  public async Task<bool> IsAuthenticated() {
    var authState = await GetAuthenticationStateAsync();
    return authState?.User?.Identity?.IsAuthenticated == true;
  }

  public async Task<int> GetId() {
    var authState = await GetAuthenticationStateAsync();
    var id = authState?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    return int.Parse(id ?? "0");
  }
  public async Task<AdminDto> GetAdmin() {
    var authState = await GetAuthenticationStateAsync();
    var adminDto = new AdminDto();
    adminDto.Id = int.Parse(authState?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
    adminDto.EmailAddress = authState?.User?.FindFirstValue(ClaimTypes.Email) ?? "";
    adminDto.RoleName = authState?.User?.FindFirstValue(ClaimTypes.Role) ?? "";
    adminDto.Permissions = authState?.User?.FindFirstValue(ExtClaimTypes.EndPointPermissions)?.Split(',') ?? new string[0];
    adminDto.Password = authState?.User?.FindFirstValue(ClaimTypes.Hash) ?? "";
    adminDto.RegisterDate = DateTime.Parse(authState?.User?.FindFirstValue("RegisterDate") ?? "", CultureInfo.InvariantCulture);
    adminDto.TwoFactorType = byte.Parse(authState?.User?.FindFirstValue("TwoFactorType") ?? "0");
    return adminDto;

  }

  public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
    //var identity = _anonymous.Identity as ClaimsIdentity;
    try {
      var login = await _protectedSessionStorage.GetAsync<AdminLoginResponse>(AdminLoginKey);
      var session = login.Success ? login.Value : null;
      if (session == null) {
        return new AuthenticationState(_anonymous);
      }
      var principal = CreatePrincipalFromLoginResponse(session);
      return await Task.FromResult(new AuthenticationState(principal));
    } catch (Exception ex) {
      Log.Error(ex, "Error getting authentication state");
      return new AuthenticationState(_anonymous);
    }
  }

  public async Task Logout() {
    await _protectedSessionStorage.DeleteAsync(AdminLoginKey);
    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
  }
  public async Task Login(AdminLoginResponse adminLoginResponse) {
    if (adminLoginResponse == null) { throw new ArgumentNullException(nameof(adminLoginResponse));}
    await _protectedSessionStorage.SetAsync(AdminLoginKey, adminLoginResponse);
    var claimsPrincipal = CreatePrincipalFromLoginResponse(adminLoginResponse);
    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
  }

  private static ClaimsPrincipal CreatePrincipalFromLoginResponse(AdminLoginResponse adminLoginResponse) {
    var admin = adminLoginResponse.Admin;
    var claims = new List<Claim>();
    //claims.Add(new Claim("AdminOnly", "true"));
    claims.Add(new Claim(ClaimTypes.Role, admin.RoleName));
    claims.Add(new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()));
    claims.Add(new Claim(ClaimTypes.Email, admin.EmailAddress));
    claims.Add(new Claim("RoleId", admin.RoleId.ToString()));
    claims.Add(new Claim("TwoFactorType", admin.TwoFactorType.ToString()));
    claims.Add(new Claim("RegisterDate", admin.RegisterDate.ToString(CultureInfo.InvariantCulture)));
    claims.Add(new Claim(ClaimTypes.Hash, admin.Password));
    if (ConstantMgr.IsDevelopment())
      claims.Add(new Claim(ExtClaimTypes.AllPermissions, "true"));
    else {
      var permissions = admin.Permissions.ToList().CreatePermissionString();
      claims.Add(new Claim(ExtClaimTypes.EndPointPermissions, permissions));
    }
    return new ClaimsPrincipal(new ClaimsIdentity(claims, AdminAuthType));
  }
}