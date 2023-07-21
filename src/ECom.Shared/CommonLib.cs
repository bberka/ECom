namespace ECom.Shared;

public static class CommonLib
{
  public static bool IsCultureValid(string cultureName) {
    if (string.IsNullOrEmpty(cultureName)) return false;
    if (!GetCultureNames().Contains(cultureName)) return false;
    return true;
  }

  public static string[] GetCultureNames() {
    return Enum.GetNames<Language>().Select(x => x.Replace("_","-")).ToArray();
  }

  public static string[] GetAdminOperationTypes() {
    return Enum.GetNames<AdminPermission>();
  }

  public static string[] GetCurrencyTypes() {
    return Enum.GetNames<Currency>();
  }
}