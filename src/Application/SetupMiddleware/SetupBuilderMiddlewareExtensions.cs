using System.Reflection;
using Microsoft.AspNetCore.Builder;

namespace ECom.Application.SetupMiddleware;

public static class SetupBuilderMiddlewareExtensions
{
  /// <summary>
  ///   This will enable any classes implementing IBuilderServiceSetup
  /// </summary>
  /// <param name="builder"></param>
  /// <param name="assembly"></param>
  public static void UseBuilderSetup(this WebApplicationBuilder builder, Assembly assembly) {
    var results = assembly.ExportedTypes
      .Where(x => typeof(IBuilderServiceSetup).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
      .OrderBy(x => x.GetCustomAttribute<InitializeOrderAttribute>()?.Order ?? 0)
      .Select(Activator.CreateInstance).Cast<IBuilderServiceSetup>();

    foreach (var result in results) result.InitializeServices(builder.Services, builder.Configuration, builder.Host);
  }
}