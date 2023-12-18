namespace ECom.Foundation.DTOs.Request;

public class Request_Token_Refresh
{
  [Required]
  public Guid Id { get; set; }

  [Required]
  public string RefreshToken { get; set; }
}