using System.Reflection;

namespace ECom.Domain.Constants;

public static class ConstantMgr
{
  public static readonly DateTime DefaultDateTime = new DateTime(1900, 1, 1);
  public const byte StringMinLength = 3;

  public const byte NameMinLength = 3;
  public const byte NameMaxLength = 64;


  public const byte EmailMaxLength = 255;

  public const byte PasswordMinLength = 3;
  public const byte PasswordMaxLength = 255;

  public const byte TitleMinLength = 3;
  public const byte TitleMaxLength = 32;
  public const byte PhoneNumberMinLength = 10;
  public const byte PhoneNumberMaxLength = 15;

  public const string DefaultCulture = "tr";
  public const CurrencyType DefaultCurrency = CurrencyType.Lira;


  public static readonly string VERSION = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ??
                                          throw new ArgumentNullException(nameof(AssemblyName.Version));

  public static bool IsDevelopment() {
#if DEBUG || RELEASE_TEST
    return true;
#endif
    return false;
  }
}