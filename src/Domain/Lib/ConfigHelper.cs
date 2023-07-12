using System.ComponentModel;
using System.Configuration;

namespace ECom.Domain.Lib;

public static class ConfigHelper
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