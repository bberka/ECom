namespace ECom.Shared;

public readonly struct LocParam
{
  public string Key { get; }
  public object Value { get; }

  public LocParam(string key, object value) {
    Key = key;
    Value = value;
  }
}