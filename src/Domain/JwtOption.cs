namespace ECom.Domain;

public class JwtOption
{
  private static JwtOption? Instance;

  private JwtOption() {
    Secret = ConfigHelper.GetString("JwtSecret") ?? throw new NullException(nameof(Secret));
    Issuer = ConfigHelper.GetString("JwtIssuer");
    Audience = ConfigHelper.GetString("JwtAudience");
    TokenExpireMinutes = ConfigHelper.Get<int>("JwtTokenExpireMinutes");
    SessionExpireMinutes = ConfigHelper.Get<int>("SessionExpireMinutes");
    if (TokenExpireMinutes == 0) TokenExpireMinutes = 720;
  }

  public static JwtOption This {
    get {
      Instance ??= new JwtOption();
      return Instance;
    }
  }

  public string Secret { get; init; }
  public string? Issuer { get; }
  public bool ValidateIssuer => !Issuer.IsNullOrEmpty();
  public string? Audience { get; }
  public bool ValidateAudience => !Audience.IsNullOrEmpty();
  public int TokenExpireMinutes { get; } = 720;
  public int SessionExpireMinutes { get; } = 720;
  public string CookieName { get; set; }
}