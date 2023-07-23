namespace ECom.Shared.DTOs;

public class JwtToken
{
  public string Token { get; set; } = null!;
  public string? RefreshToken { get; set; } 
  public long ExpireUnix { get; set; }
}