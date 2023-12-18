using ECom.Foundation.DTOs;
using ECom.Foundation.DTOs.Request;

namespace ECom.Foundation.Abstract.Services.Admin;

public interface IAdminAnnouncementService
{
  Result DeleteAnnouncement(Guid id);
  Result UpdateAnnouncement(Request_Announcement_Update data);
  Result UpdateAnnouncementsOrder(List<NestableListElementDto> activeAnnouncements);
  Result AddAnnouncement(Request_Announcement_Add data);
}