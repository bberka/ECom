namespace ECom.Shared.DTOs;

public class JwtToken
{
  public string Token { get; set; } = null!;
  public long ExpireUnix { get; set; }
}