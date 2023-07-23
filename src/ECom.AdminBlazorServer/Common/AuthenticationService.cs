using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace ECom.AdminBlazorServer.Common;

public class AuthenticationService
{
  private ClaimsPrincipal? currentUser;

  public ClaimsPrincipal CurrentUser {
    get => currentUser ?? new ClaimsPrincipal();
    set {
      currentUser = value;
      UserChanged?.Invoke(currentUser);
    }
  }

  public AuthenticationState State => new(CurrentUser);
  public event Action<ClaimsPrincipal>? UserChanged;
}