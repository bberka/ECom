namespace ECom.Domain.ValueObjects;

public class JwtOption
{
  private static JwtOption? Instance;

  private JwtOption() {
    Secret = ConfigHelper.GetString("JwtSecret") ?? throw new NullException(nameof(Secret));
    Issuer = ConfigHelper.GetString("JwtIssuer");
    Audience = ConfigHelper.GetString("JwtAudience");
    TokenExpireMinutes = ConfigHelper.Get<int>("JwtTokenExpireMinutes");
    if (TokenExpireMinutes == 0) TokenExpireMinutes = 720;
  }

  public static JwtOption This {
    get {
      Instance ??= new JwtOption();
      return Instance;
    }
  }

  public string Secret { get; set; }
  public string? Issuer { get; set; }
  public bool ValidateIssuer => !Issuer.IsNullOrEmpty();
  public string? Audience { get; set; }
  public bool ValidateAudience => !Audience.IsNullOrEmpty();
  public int TokenExpireMinutes { get; set; } = 720;
}