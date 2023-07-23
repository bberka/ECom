using System.Security.Claims;

namespace ECom.AdminBlazorServer.Common;

public class AuthenticationService
{
  public event Action<ClaimsPrincipal>? UserChanged;
  private ClaimsPrincipal? currentUser;

  public ClaimsPrincipal CurrentUser {
    get => currentUser ?? new();
    set {
      currentUser = value;
      UserChanged?.Invoke(currentUser);
    }
  }
}