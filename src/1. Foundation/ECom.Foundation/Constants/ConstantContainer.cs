using System.Reflection;
using ECom.Foundation.Enum;

namespace ECom.Foundation.Constants;

public static class ConstantContainer
{
  public const LanguageType DefaultLanguage = LanguageType.en;
  public const CurrencyType DefaultCurrency = CurrencyType.Lira;

  public const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
  public const string Numbers = "0123456789";
  public const string AlphabetAndNumbers = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
  public const string SpecialChars = "!@#$%^&*()_+";
  public const string PasswordAllowedCharacters = AlphabetAndNumbers + SpecialChars;
  public const int MinGlobalStringLength = 1;
  public const int MaxGlobalStringLength = 1000;
  public const int MinPasswordLength = 6;
  public const int MaxPasswordLength = 32;
  public const int MinHashedPasswordLength = 1;
  public const int MaxHashedPasswordLength = 256;
  public const int MinNameLength = 2;
  public const int MaxNameLength = 50;
  public const int MinPhoneLength = 8;
  public const int MaxPhoneLength = 14;
  public const int MinAddressLength = 3;
  public const int MaxAddressLength = 200;
  public const int MinCityLength = 2;
  public const int MaxCityLength = 100;
  public const int MinCountryLength = 2;
  public const int MaxCountryLength = 100;
  public const int MinPostalCodeLength = 2;
  public const int MaxPostalCodeLength = 20;
  public const int MinDescriptionLength = 2;
  public const int MaxDescriptionLength = 500;
  public const int MinProductDescriptionLength = 20;
  public const int MaxProductDescriptionLength = int.MaxValue;
  public const int MinTitleLength = 8;
  public const int MaxTitleLength = 128;
  public const int MinMessageLength = 4;
  public const int MaxMessageLength = 128;
  public const int MinCultureLength = 2;
  public const int MaxCultureLength = 4;
  public const int MaxMemoLength = 128;
  public const int MaxCouponLength = 32;
  public const int MinCouponLength = 6;
  public const int MaxTokenLength = 512;
  public const int MinTokenLength = 512;
  public const int MaxProductCommentLength = 1000;
  public const int MinProductCommentLength = 16;
  public const int MinProductShortLength = 512;
  public const int MaxProductShortLength = 6;
  public const int MaxImageAltLength = 64;
  public const int MaxOperationLength = 64;
  public const int MaxErrorCodeLength = 128;
  public const int MaxDomainLength = 512;
  public const int MinEmailLength = 2;
  public const int MaxEmailLength = 512;
  public const int MaxReasonLength = 64;
  public const int MaxPageElementCountLimit = 100;
  public const int MinPageElementCountLimit = 5;
  public const int MaxImageCountLimit = 30;
  public const int MinImageCountLimit = 1;
  public const int MaxTokenExpireLimit = 43200;
  public const int MinTokenExpireLimit = 15;

  public const int MaxPortValue = 65535;

  public const int MinPortValue = 1;

  public const int Hundred = 100;
  public const int Fifty = 10;

  public const int Ten = 10;

  public const int MaxExtensionLength = 12;

  public const string SupportedImageExtensions = "jpg|jpeg|png|gif|bmp|webp";
  public const int MaxContentTypeHeaderLength = 32;

  public const int MaxMainCategoryLimit = 6;
  public const int MaxSubCategoryLimit = 20;
  public const int MaxTypeNameLength = 32;
  public const int MaxLanguageKeyLength = 64;
  public const int MaxAttributeNameLength = 64;
  public const int MaxAttributeValueLength = 500;
  public const int MaxAnnouncementCount = 4;

  public const bool SingletonDbTableKey = true;
  public const int MaxEmailContentLength = int.MaxValue;
  public const int MaxEmailTitleLength = 64;
  public static readonly DateTime DefaultDateTime = new(1900, 1, 1);

  public static readonly List<AdminPermissionType> AdminPermissionTypes = System.Enum.GetValues<AdminPermissionType>().ToList();
  public static readonly List<CurrencyType> CurrencyTypes = System.Enum.GetValues<CurrencyType>().ToList();
  public static readonly List<SmtpHostType> SmtpHostTypes = System.Enum.GetValues<SmtpHostType>().ToList();
  public static readonly List<PaymentType> PaymentTypes = System.Enum.GetValues<PaymentType>().ToList();
  public static readonly List<string> LanguageNames = System.Enum.GetValues<LanguageType>().Select(x => x.ToString()).ToList();
  public static readonly List<LanguageType> Languages = System.Enum.GetValues<LanguageType>().ToList();

  public static readonly string Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ??
                                          throw new ArgumentNullException(nameof(AssemblyName.Version));

  public static bool IsCultureValid(string cultureName) {
    if (string.IsNullOrEmpty(cultureName)) return false;
    if (!LanguageNames.Contains(cultureName)) return false;
    return true;
  }

  public static bool IsDevelopment() {
    #if DEBUG || RELEASE_TEST
    return true;
    #endif
    return false;
  }
}