using System.Reflection;
using Microsoft.AspNetCore.Builder;

namespace ECom.Application.SetupMiddleware;

public static class SetupApplicationMiddlewareExtensions
{
  /// <summary>
  ///   This will enable any classes implementing IApplicationSetup
  /// </summary>
  /// <param name="app"></param>
  /// <param name="assembly"></param>
  public static void UseApplicationSetup(this WebApplication app, Assembly assembly) {
    var results = assembly.ExportedTypes
      .Where(x => typeof(IApplicationSetup).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
      .OrderBy(x => x.GetCustomAttribute<InitializeOrderAttribute>()?.Order ?? 0)
      .Select(Activator.CreateInstance).Cast<IApplicationSetup>();

    foreach (var result in results) result.InitializeApplication(app);
  }
}