using ECom.Foundation.Exceptions;
using ECom.Foundation.Lib;

namespace ECom.Foundation.Static;

public sealed class DomAppSettings
{
  private static DomAppSettings? _instance;

  private DomAppSettings() {
    JwtSecret = ConfigLib.GetString("JWT_SECRET") ?? throw new NullException(nameof(JwtSecret));
    JwtIssuer = ConfigLib.GetString("JWT_ISSUER");
    JwtAudience = ConfigLib.GetString("JWT_AUDIENCE");
    JwtTokenExpireMinutes = ConfigLib.Get<int>("JWT_TOKEN_EXPIRE_MINUTES");
    SessionExpireMinutes = ConfigLib.Get<int>("SESSION_EXPIRE_MINUTES");
    if (JwtTokenExpireMinutes < 1) JwtTokenExpireMinutes = 720;
    if (SessionExpireMinutes < 1) JwtTokenExpireMinutes = 720;
    AdminCookieName = ConfigLib.GetString("ADMIN_COOKIE_NAME") ?? throw new NullException(nameof(AdminCookieName));
    UserCookieName = ConfigLib.GetString("USER_COOKIE_NAME") ?? throw new NullException(nameof(UserCookieName));
    ImageResourceDirectory = ConfigLib.GetString("IMAGE_RESOURCE_DIRECTORY") ?? throw new NullException(nameof(ImageResourceDirectory));
    SessionCookieName = ConfigLib.GetString("SESSION_COOKIE_NAME") ?? throw new NullException(nameof(SessionCookieName));
    DatabaseConnectionString = ConfigLib.GetString("DATABASE_CONNECTION") ?? throw new NullException(nameof(DatabaseConnectionString));
    EnableSwagger = ConfigLib.Get<bool>("ENABLE_SWAGGER");
    HostUrl = ConfigLib.Get<string>("HOST_URL");
  }


  public static DomAppSettings This {
    get {
      _instance ??= new DomAppSettings();
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
  public bool EnableSwagger { get; }

  public string HostUrl { get; set; }
}