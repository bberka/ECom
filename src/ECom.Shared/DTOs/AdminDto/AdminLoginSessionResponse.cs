namespace ECom.Shared.DTOs.AdminDto;

public class AdminLoginSession
{
  private AdminLoginSession() {
    
  }
  public AdminDto Admin{ get; init; }
  public DateTime ExpireTime { get; init; }

  public static AdminLoginSession Create(AdminDto adminDto, TimeSpan expireTimeSpan) {
    if(adminDto == null) throw new ArgumentNullException(nameof(adminDto));
    if(expireTimeSpan.TotalSeconds <= 0) throw new ArgumentOutOfRangeException(nameof(expireTimeSpan));
    return new AdminLoginSession {
      Admin = adminDto,
      ExpireTime = DateTime.Now.Add(expireTimeSpan),
    };
  }
}