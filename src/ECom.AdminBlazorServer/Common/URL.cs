namespace ECom.AdminBlazorServer.Common;

public static class URL
{
  public const string BaseApiUrl = "/api/" + Version + "/"; //https://localhost:44300
  public const string Version = "v0.1.0";
  public const string GetLanguagePacks = "localization/packs";
  public const string GetAdmins = "manager/getadmins";

  public static string BuildUrl(string url) {
    return BaseApiUrl + url;
  }
}