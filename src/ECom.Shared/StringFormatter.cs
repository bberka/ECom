namespace ECom.Shared;

public class StringFormatter
{
  public StringFormatter(string text) {
    Text = text;
    Parameters = new Dictionary<string, object>();
  }

  private string Text { get; set; }
  private string? _formattedText; 

  private Dictionary<string, object> Parameters { get; set; }

  
  public bool AddArgument(string key, object? value) {
    if (key.Contains(' ')) throw new InvalidOperationException(nameof(key) + " can not contain spaces");
    if (value is null) throw new InvalidOperationException(nameof(value) + " can not be null");
    var exists = Parameters.ContainsKey(key);
    if (exists) return false;
    Parameters.Add(key, value); // example: @@age must be in the string
    return true;
  }
  public bool AddArgument(LocalizationParam param) {
    return AddArgument(param.TranslatedKey, param.Value);
  }

  public override string ToString() {
    if(_formattedText is not null) return _formattedText;
    _formattedText = Text;
    foreach (var parameter in Parameters) {
      _formattedText = _formattedText.Replace($"@@{parameter.Key}", parameter.Value.ToString());
    }
    return _formattedText;
  }
}