namespace ECom.Foundation.DTOs.Request;

public class Request_Announcement_Update
{
  public Guid Id { get; set; }
  public int Order { get; set; }

  public List<ContentDto> Contents { get; set; }
  public DateTime ExpireDate { get; set; }
}