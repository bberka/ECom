namespace ECom.Domain.Extensions;

public static class StringExtensions
{
  public static string ToEncryptedText(this string str) {
    return str.MD5Hash().ToHexString();
  }
}