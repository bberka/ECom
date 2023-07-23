using System.Data.SqlTypes;
using System.Globalization;
using System.Security.Claims;
using AspNetCore.Authorization.Extender;
using ECom.Shared.Constants;
using ECom.Shared.DTOs.AdminDto;
using Microsoft.AspNetCore.Components.Authorization;
using Serilog;

namespace ECom.AdminBlazorServer.Common;

public static class AuthExtensions
{

  public static AdminDto GetAdmin(this ClaimsPrincipal user) {
    try {
      var adminDto = new AdminDto();
      adminDto.Id = Guid.Parse(user?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
      adminDto.EmailAddress = user?.FindFirstValue(ClaimTypes.Email) ?? "";
      adminDto.RoleId = user?.FindFirstValue(ClaimTypes.Role) ?? "";
      adminDto.Permissions = user?.FindFirstValue(ExtClaimTypes.EndPointPermissions)?.Split(',') ?? Array.Empty<string>();
      adminDto.Password = user?.FindFirstValue(ClaimTypes.Hash) ?? "";
      adminDto.RegisterDate = DateTime.Parse(user?.FindFirstValue("RegisterDate") ?? "", CultureInfo.InvariantCulture);
      adminDto.TwoFactorType = Enum.Parse<TwoFactorType>(user?.FindFirstValue("TwoFactorType") ?? "0");
      return adminDto;
    } catch (Exception ex) {
      Log.Error(ex, "AuthExtensions.GetAdmin");
      return new AdminDto();
    }

  }

  public static Guid GetAdminId(this ClaimsPrincipal user) {
    var val = user?.FindFirstValue(ClaimTypes.NameIdentifier);
    return val == null ? Guid.Empty : Guid.Parse(val);
  }

  public static bool IsAuthenticated(this AuthenticationState authenticationState) {
    return authenticationState?.User?.Identity?.IsAuthenticated == true;
  }

  public static AdminDto GetAdmin(this AuthenticationState state) {
    return state.User.GetAdmin();
  }

  public static Guid GetAdminId(this AuthenticationState state) {
    return state.User.GetAdminId();
  }


}