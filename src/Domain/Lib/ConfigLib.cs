using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Lib
{
	public static class ConfigLib
	{
		public static string? GetString(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}
		public static T? Get<T>(string key)
		{
			var configValue = ConfigurationManager.AppSettings[key]?.ToString();
			if (configValue is null) return default;
			var type = typeof(T);
			var converter = TypeDescriptor.GetConverter(type);

			if(converter.CanConvertTo(type) && converter.CanConvertFrom(typeof(string)))
			{
				var value = (T?)converter.ConvertFromString(configValue);
				if (value is null) return default;
				return value;
			}
			return default;
		}
	}
}
