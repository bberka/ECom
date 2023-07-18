﻿namespace ECom.Domain;

public class StringFormatter
{

  public string Text { get; set; }

  public Dictionary<string, object> Parameters { get; set; }

  public StringFormatter(string text) {
    Text = text;
    Parameters = new Dictionary<string, object>();
  }

  public bool Add(string key, string? value) {
    if (key.Contains(' ')) throw new InvalidOperationException(nameof(key) + " can not contain spaces");
    if (string.IsNullOrEmpty(value)) throw new InvalidOperationException(nameof(value) + " can not be null");
    var exists = Parameters.ContainsKey(key);
    if (exists) return false;
    Parameters.Add($"@@{key}", value); // example: @@age must be in the string
    return true;
  }

  public override string ToString() {
    return Parameters.Aggregate(Text, (current, parameter) => current.Replace(parameter.Key, parameter.Value.ToString()));
  }

}