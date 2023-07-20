namespace ECom.Shared;

public record LocalizationParam(string Key, string Value)
{
  public KeyValuePair<string, object> ToKeyValuePair() {
    return  new(Key, Value);
  }

  public string TranslatedKey { get; set; }

}
