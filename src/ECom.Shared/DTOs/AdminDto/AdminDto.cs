namespace ECom.Shared.DTOs.AdminDto;

public class AdminDto
{
  public DateTime RegisterDate { get; set; }
  public Guid Id { get; set; }
  public string EmailAddress { get; set; }
  public TwoFactorType TwoFactorType { get; set; }
  public string RoleId { get; set; }
  public string[] Permissions { get; set; } = Array.Empty<string>();
  public string Password { get; set; }
  public DateTime? DeletedDate { get; set; }
}