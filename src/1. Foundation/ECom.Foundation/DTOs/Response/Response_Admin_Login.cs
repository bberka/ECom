namespace ECom.Foundation.DTOs.Response;

public class Response_Admin_Login
{
  public AdminDto Admin { get; set; } = null!;
  public JwtToken Token { get; set; } = null!;
}