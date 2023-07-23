using System.Reflection;

namespace ECom.Shared.Constants;

public static class ConstantMgr
{
  public const string DefaultCulture = "tr";
  public const Currency DefaultCurrency = Currency.Lira;
  public static readonly DateTime DefaultDateTime = new(1900, 1, 1);


  public static readonly string VERSION = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ??
                                          throw new ArgumentNullException(nameof(AssemblyName.Version));

  public static bool IsDevelopment() {
#if DEBUG || RELEASE_TEST
    return true;
#endif
    return false;
  }
}