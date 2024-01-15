using ECom.Foundation.Static;

namespace ECom.Foundation.DTOs.Request;

public class Request_Announcement_Add
{
  public int Order { get; set; } = 0;
  public DateTime ExpireDate { get; set; } = DateTime.Now.AddMinutes(StaticValues.ANNOUNCEMENT_DEFAULT_EXPIRE_MINUTES);
  public ContentDto Content { get; set; }
}