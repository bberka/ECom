using ECom.Foundation.Enum;

namespace ECom.Foundation.DTOs.Request;

public class Request_Announcement_Add
{
  public int Order { get; set; } = 0;
  public DateTime ExpireDate { get; set; } = DateTime.Now.AddMinutes(ConstantContainer.AnnouncementDefaultExpireMinutes);
  public List<AnnouncementContentDto> Contents { get; set; }
}