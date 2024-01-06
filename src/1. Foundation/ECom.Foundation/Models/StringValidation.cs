using ECom.Foundation.Static;

namespace ECom.Foundation.Models;

public class StringValidation
{
  public StringValidation(ValidationType type, int min, int max, string locKey) {
    Min = min;
    Max = max;
    LocKey = locKey;
    Type = type;
  }

  public ValidationType Type { get; init; }
  public int Min { get; init; }
  public int Max { get; init; }
  public string LocKey { get; init; }
}