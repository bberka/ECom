using EasMe.Extensions;

namespace ECom.Shared.Extensions;
public static class BasicValidationExtensions
{

  public static bool HasSpecialChar(this string text) {
    return text.ContainsSpecialChars();
  }

  public static bool HasNumber(this string text) {
    return text.Any(char.IsDigit);
  }

  public static bool HasLowerCase(this string text) {
    return text.Any(char.IsLower);
  }

  public static bool HasUpperCase(this string text) {
    return text.Any(char.IsUpper);
  }

  public static bool HasSpace(this string text) {
    return text.Any(x => x != ' ');
  }
}