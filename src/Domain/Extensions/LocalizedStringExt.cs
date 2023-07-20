using Microsoft.Extensions.Localization;

namespace ECom.Domain.Extensions;

public static class LocalizedStringExt
{
  //public static string Format(this LocalizedString str,string key, object value) {
  //  return str.Value.Replace($"@@{key}", value.ToString());
  //}
  //public static string Format(this string str, string key, object value) {
  //  return str.Replace($"@@{key}", value.ToString());
  //}
  public static LocalizedString Format(this LocalizedString str, string key, object value) {
    return new LocalizedString(key, str.Value.Replace($"{{{key}}}", value.ToString()),false);
  }
}