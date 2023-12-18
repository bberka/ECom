using ECom.Foundation.Exceptions;
using ECom.Foundation.Lib;

namespace ECom.Foundation.Constants;

public sealed class EComAppSettings
{
  private static EComAppSettings? _instance;

  private EComAppSettings() {
    JwtSecret = ConfigLib.GetString("JwtSecret") ?? throw new NullException(nameof(JwtSecret));
    JwtIssuer = ConfigLib.GetString("JwtIssuer");
    JwtAudience = ConfigLib.GetString("JwtAudience");
    JwtTokenExpireMinutes = ConfigLib.Get<int>("JwtTokenExpireMinutes");
    SessionExpireMinutes = ConfigLib.Get<int>("SessionExpireMinutes");
    if (JwtTokenExpireMinutes < 1) JwtTokenExpireMinutes = 720;
    if (SessionExpireMinutes < 1) JwtTokenExpireMinutes = 720;
    AdminCookieName = ConfigLib.GetString("AdminCookieName") ?? throw new NullException(nameof(AdminCookieName));
    UserCookieName = ConfigLib.GetString("UserCookieName") ?? throw new NullException(nameof(UserCookieName));
    ImageResourceDirectory = ConfigLib.GetString("ImageResourceDirectory") ?? throw new NullException(nameof(ImageResourceDirectory));
    SessionCookieName = ConfigLib.GetString("SessionCookieName") ?? throw new NullException(nameof(SessionCookieName));
    DatabaseConnectionString = ConfigLib.GetString("DatabaseConnectionString") ?? throw new NullException(nameof(DatabaseConnectionString));
  }

  public static EComAppSettings This {
    get {
      _instance ??= new EComAppSettings();
      return _instance;
    }
  }

  public string JwtSecret { get; }
  public string? JwtIssuer { get; }
  public bool JwtValidateIssuer => !JwtIssuer.IsNullOrEmpty();
  public string? JwtAudience { get; }
  public bool JwtValidateAudience => !JwtAudience.IsNullOrEmpty();
  public int JwtTokenExpireMinutes { get; } = 720;
  public int SessionExpireMinutes { get; } = 720;
  public string AdminCookieName { get; }
  public string UserCookieName { get; }
  public string ImageResourceDirectory { get; }
  public string SessionCookieName { get; }
  public string DatabaseConnectionString { get; }
}