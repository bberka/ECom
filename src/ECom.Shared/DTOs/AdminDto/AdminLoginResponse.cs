namespace ECom.Shared.DTOs.AdminDto;

public class AdminLoginResponse
{
  public AdminDto Admin { get; set; } = null!;
  public JwtToken Token { get; set; } = null!;
  
}