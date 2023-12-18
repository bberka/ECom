﻿namespace ECom.Foundation.Lib;

public static class HashLib
{
  public static string ToHashedText(this string str) {
    return str.MD5Hash().ToHexString().SHA256Hash().ToHexString();
  }
  // public static string ToHashedTextV2(this string str) {
  //   return str.MD5Hash().ToHexString().SHA256Hash().ToHexString().ToUpper();
  // }
}