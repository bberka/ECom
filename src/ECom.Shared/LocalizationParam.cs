namespace ECom.Shared;

public record LocalizationParam(string Key, string Value)
{
  public string TranslatedKey { get; set; }

  public KeyValuePair<string, object> ToKeyValuePair() {
    return new KeyValuePair<string, object>(Key, Value);
  }
}
