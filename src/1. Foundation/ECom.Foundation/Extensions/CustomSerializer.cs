namespace ECom.Foundation.Extensions;

public static class CustomSerializer
{
  public static string SerializeJson(this object obj) {
    return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings {
      ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
      NullValueHandling = NullValueHandling.Include
    });
  }
}