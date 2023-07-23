namespace ECom.Domain;

public static class Encryptor
{
  public static string ToEncryptedText(this string str) {
    return str.MD5Hash().ToHexString() /*.SHA256Hash().ToHexString()*/;
  }
}