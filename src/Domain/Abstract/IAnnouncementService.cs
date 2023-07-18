using ECom.Domain.DTOs.AnnouncementDto;

namespace ECom.Domain.Abstract;

public interface IAnnouncementService
{
  List<Announcement> ListAnnouncements();
  CustomResult DeleteAnnouncement(uint id);
  //CustomResult EnableAnnouncement(uint id);
  //CustomResult DisableAnnouncement(uint id);
  CustomResult UpdateAnnouncement(UpdateAnnouncementRequest data);
  CustomResult AddAnnouncement(AddAnnouncementRequest data);
}