using System.Globalization;
using System.Reflection;

namespace ECom.Foundation.Static;

public static class StaticValues
{
  public const CultureType DEFAULT_LANGUAGE = CultureType.en_us;
  public const CurrencyType DEFAULT_CURRENCY = CurrencyType.TRY;

  public const string ALPHABET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
  public const string NUMBERS = "0123456789";
  public const string ALPHABET_AND_NUMBERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
  public const string SPECIAL_CHARS = "!@#$%^&*()_+";
  public const string PASSWORD_ALLOWED_CHARACTERS = ALPHABET_AND_NUMBERS + SPECIAL_CHARS;
  public const int MIN_GLOBAL_STRING_LENGTH = 1;
  public const int MAX_GLOBAL_STRING_LENGTH = 1000;
  public const int MIN_PASSWORD_LENGTH = 6;
  public const int MAX_PASSWORD_LENGTH = 32;
  public const int MIN_HASHED_PASSWORD_LENGTH = 1;
  public const int MAX_HASHED_PASSWORD_LENGTH = 256;
  public const int MIN_NAME_LENGTH = 2;
  public const int MAX_NAME_LENGTH = 50;
  public const int MIN_PHONE_LENGTH = 8;
  public const int MAX_PHONE_LENGTH = 14;
  public const int MIN_ADDRESS_LENGTH = 3;
  public const int MAX_ADDRESS_LENGTH = 200;
  public const int MIN_CITY_LENGTH = 2;
  public const int MAX_CITY_LENGTH = 100;
  public const int MIN_COUNTRY_LENGTH = 2;
  public const int MAX_COUNTRY_LENGTH = 100;
  public const int MIN_POSTAL_CODE_LENGTH = 2;
  public const int MAX_POSTAL_CODE_LENGTH = 20;
  public const int MIN_DESCRIPTION_LENGTH = 2;
  public const int MAX_DESCRIPTION_LENGTH = 500;
  public const int MIN_PRODUCT_DESCRIPTION_LENGTH = 20;
  public const int MAX_PRODUCT_DESCRIPTION_LENGTH = int.MaxValue;
  public const int MIN_TITLE_LENGTH = 8;
  public const int MAX_TITLE_LENGTH = 128;
  public const int MIN_MESSAGE_LENGTH = 4;
  public const int MAX_MESSAGE_LENGTH = 128;
  public const int MIN_CULTURE_LENGTH = 2;
  public const int MAX_CULTURE_LENGTH = 4;
  public const int MAX_MEMO_LENGTH = 128;
  public const int MAX_COUPON_LENGTH = 32;
  public const int MIN_COUPON_LENGTH = 6;
  public const int MAX_TOKEN_LENGTH = 512;
  public const int MIN_TOKEN_LENGTH = 512;
  public const int MAX_PRODUCT_COMMENT_LENGTH = 1000;
  public const int MIN_PRODUCT_COMMENT_LENGTH = 16;
  public const int MIN_PRODUCT_SHORT_LENGTH = 512;
  public const int MAX_PRODUCT_SHORT_LENGTH = 6;
  public const int MAX_IMAGE_ALT_LENGTH = 64;
  public const int MAX_OPERATION_LENGTH = 64;
  public const int MAX_ERROR_CODE_LENGTH = 128;
  public const int MAX_DOMAIN_LENGTH = 512;
  public const int MIN_EMAIL_LENGTH = 2;
  public const int MAX_EMAIL_LENGTH = 512;
  public const int MAX_REASON_LENGTH = 64;
  public const int MAX_PAGE_ELEMENT_COUNT_LIMIT = 100;
  public const int MIN_PAGE_ELEMENT_COUNT_LIMIT = 5;
  public const int MAX_IMAGE_COUNT_LIMIT = 30;
  public const int MIN_IMAGE_COUNT_LIMIT = 1;
  public const int MAX_TOKEN_EXPIRE_LIMIT = 43200;
  public const int MIN_TOKEN_EXPIRE_LIMIT = 15;

  public const int MAX_PORT_VALUE = 65535;

  public const int MIN_PORT_VALUE = 1;

  public const int HUNDRED = 100;
  public const int FIFTY = 50;
  public const int TEN = 10;


  public const int MAX_EXTENSION_LENGTH = 12;

  public const string SUPPORTED_IMAGE_EXTENSIONS = "jpg|jpeg|png|gif|bmp|webp";
  public const int MAX_CONTENT_TYPE_HEADER_LENGTH = 32;

  public const int MAX_MAIN_CATEGORY_LIMIT = 6;
  public const int MAX_SUB_CATEGORY_LIMIT = 20;
  public const int MAX_TYPE_NAME_LENGTH = 32;
  public const int MAX_LANGUAGE_KEY_LENGTH = 64;
  public const int MAX_ATTRIBUTE_NAME_LENGTH = 64;
  public const int MAX_ATTRIBUTE_VALUE_LENGTH = 500;
  public const int MAX_ANNOUNCEMENT_COUNT = 4;

  public const bool SINGLETON_DB_TABLE_KEY = true;
  public const int MAX_EMAIL_CONTENT_LENGTH = int.MaxValue;
  public const int MAX_EMAIL_TITLE_LENGTH = 64;
  public const int MAX_ANNOUNCEMENT_MESSAGE_LENGTH = 128;
  public const int MIN_ANNOUNCEMENT_MESSAGE_LENGTH = 6;

  public const int ANNOUNCEMENT_DEFAULT_EXPIRE_MINUTES = 24 * 60;
  public static readonly CultureInfo DEFAULT_CULTURE = new(DEFAULT_CULTURE_NAME);
  public static readonly string DEFAULT_CULTURE_NAME = "en-US";
  public static readonly DateTime DEFAULT_DATE_TIME = new(1900, 1, 1);

  public static readonly List<AdminPermissionType> ADMIN_PERMISSION_TYPES = System.Enum.GetValues<AdminPermissionType>().ToList();
  public static readonly List<CurrencyType> CURRENCY_TYPES = System.Enum.GetValues<CurrencyType>().ToList();
  public static readonly List<SmtpHostType> SMTP_HOST_TYPES = System.Enum.GetValues<SmtpHostType>().ToList();
  public static readonly List<PaymentType> PAYMENT_TYPES = System.Enum.GetValues<PaymentType>().ToList();
  public static readonly List<string> LANGUAGE_NAMES = System.Enum.GetValues<CultureType>().Select(x => x.ToString()).ToList();
  public static readonly List<CultureType> LANGUAGES = System.Enum.GetValues<CultureType>().ToList();

  public static readonly string VERSION = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ??
                                          throw new ArgumentNullException(nameof(AssemblyName.Version));

  public static bool IsDevelopment {
    get {
      #if DEBUG || RELEASE_TEST
      return true;
      #endif
      return false;
    }
  }

  public static bool IsCultureValid(string cultureName) {
    if (string.IsNullOrEmpty(cultureName)) return false;
    if (!LANGUAGE_NAMES.Contains(cultureName)) return false;
    return true;
  }
}