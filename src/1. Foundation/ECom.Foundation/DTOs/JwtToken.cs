namespace ECom.Foundation.DTOs;

public class JwtToken
{
  public string Token { get; set; } = null!;
  public string? RefreshToken { get; set; }
  public long ExpireUnix { get; set; }
  public long ValidForMinutes { get; set; }
}