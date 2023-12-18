namespace ECom.Foundation.DTOs.Request;

public class Request_Announcement_Add
{
  public int Order { get; set; }

  [MaxLength(128)]
  public string Message { get; set; } = null!;

  public DateTime ExpireDate { get; set; } = DateTime.Now.AddDays(1);
}