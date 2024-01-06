using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ECom.Foundation.Lib;

public static class AsmLib
{
  public static void InitializeAllSingletons(this IServiceProvider services) {
    var assemblyList = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName?.StartsWith("ECom") == true);
    foreach (var assembly in assemblyList) {
      var allTypesThatInheritsFromSingletonBase = assembly.GetTypes()
                                                          .Where(x => x.IsSubclassOf(typeof(SingletonBase<>)));
      foreach (var type in allTypesThatInheritsFromSingletonBase) {
        try {
          //set all properties with [FromServices]

          var accessStaticThisProperty = type.GetProperty("This", BindingFlags.Public | BindingFlags.Static);
          if (accessStaticThisProperty is null) continue;
          var instance = accessStaticThisProperty.GetValue(null);
          if (instance is null) continue;
          var allPropertiesWithFromServices = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                                  .Where(x => x.GetCustomAttribute<FromServicesAttribute>() != null);
          foreach (var property in allPropertiesWithFromServices) {
            ////WARNING:
            /// IF YOU INIT A SCOPED SERVICE INSIDE A SINGLETON SERVICE IT WILL GET SKIPPED
            /// CAREFUL WITH THAT
            var value = services.GetService(property.PropertyType);
            if (value is null) continue;
            property.SetValue(instance, value);
          }
        }
        catch (Exception ex) {
          Log.Fatal(ex, "INIT Error in SingletonBase {TypeName}", type.FullName);
          throw;
        }
      }
    }
  }
}