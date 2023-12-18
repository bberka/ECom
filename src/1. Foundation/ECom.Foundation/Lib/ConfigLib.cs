using System.ComponentModel;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace ECom.Foundation.Lib;

public static class ConfigLib
{
  public static string? GetString(string key) {
    return ConfigurationManager.AppSettings[key];
  }

  public static T? Get<T>(string key) {
    var configValue = ConfigurationManager.AppSettings[key];
    if (configValue is null) return default;
    var type = typeof(T);
    var converter = TypeDescriptor.GetConverter(type);

    if (converter.CanConvertTo(type) && converter.CanConvertFrom(typeof(string))) {
      var value = (T?)converter.ConvertFromString(configValue);
      if (value is null) return default;
      return value;
    }

    return default;
  }
}