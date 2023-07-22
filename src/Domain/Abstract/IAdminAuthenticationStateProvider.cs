using Microsoft.AspNetCore.Components.Authorization;

namespace ECom.Domain.Abstract;

public interface IAdminAuthenticationStateProvider
{
  Task<AuthenticationState> GetAuthenticationStateAsync();
  Task Logout();
  Task Login(AdminDto admin);
}