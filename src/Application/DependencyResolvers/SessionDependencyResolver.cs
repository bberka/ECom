namespace ECom.Application.DependencyResolvers;

public static class SessionDependencyResolver
{
  private const int SessionTimeOutSeconds = int.MaxValue;

  public static IServiceCollection AddSessionConfigured(this IServiceCollection services) {
    services.AddSession(options => {
      options.IdleTimeout = TimeSpan.FromSeconds(SessionTimeOutSeconds);
      options.Cookie.HttpOnly = true;
      // Make the session cookie essential
      options.Cookie.IsEssential = true;
      options.Cookie.Name = ".Session.ECom";
    });
    services.AddMemoryCache();
    services.AddDataProtection();
    services.AddDistributedMemoryCache();

    return services;
  }
}