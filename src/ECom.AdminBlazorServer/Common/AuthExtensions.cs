using System.Globalization;
using System.Security.Claims;
using AspNetCore.Authorization.Extender;
using ECom.Shared.Constants;
using ECom.Shared.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using Serilog;

namespace ECom.AdminBlazorServer.Common;

public static class AuthExtensions
{
  public static ClaimsPrincipal CreatePrincipal(this AdminDto admin) {
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
    return new ClaimsPrincipal(new ClaimsIdentity(claims, "admin-auth"));
  }

  public static AdminDto GetAdmin(this ClaimsPrincipal user) {
    try {
      var adminDto = new AdminDto();
      adminDto.Id = Guid.Parse(user?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
      adminDto.EmailAddress = user?.FindFirstValue(ClaimTypes.Email) ?? "";
      adminDto.RoleId = user?.FindFirstValue(ClaimTypes.Role) ?? "";
      adminDto.Permissions =
        user?.FindFirstValue(ExtClaimTypes.EndPointPermissions)?.Split(',') ?? Array.Empty<string>();
      adminDto.Password = user?.FindFirstValue(ClaimTypes.Hash) ?? "";
      adminDto.RegisterDate = DateTime.Parse(user?.FindFirstValue("RegisterDate") ?? "", CultureInfo.InvariantCulture);
      adminDto.TwoFactorType = Enum.Parse<TwoFactorType>(user?.FindFirstValue("TwoFactorType") ?? "0");
      return adminDto;
    }
    catch (Exception ex) {
      Log.Error(ex, "AuthExtensions.GetAdmin");
      return new AdminDto();
    }
  }

  public static Guid GetAdminId(this ClaimsPrincipal user) {
    var val = user?.FindFirstValue(ClaimTypes.NameIdentifier);
    return val == null ? Guid.Empty : Guid.Parse(val);
  }

  public static bool IsAuthenticated(this AuthenticationState? authenticationState) {
    return authenticationState?.User?.Identity?.IsAuthenticated == true;
  }

  public static AdminDto GetAdmin(this AuthenticationState state) {
    return state.User.GetAdmin();
  }

  public static Guid GetAdminId(this AuthenticationState state) {
    return state.User.GetAdminId();
  }
}