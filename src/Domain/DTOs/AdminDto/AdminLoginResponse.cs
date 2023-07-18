namespace ECom.Domain.DTOs.AdminDto;

public class AdminLoginResponse
{
  public AdminDto Admin { get; set; }
  public JwtToken Token { get; set; }
}