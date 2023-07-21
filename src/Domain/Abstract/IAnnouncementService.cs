using ECom.Domain.Entities;

namespace ECom.Domain.Abstract;

public interface IAnnouncementService
{
  List<Announcement> ListAnnouncements();

  CustomResult DeleteAnnouncement(Guid id);
  CustomResult RecoverAnnouncement(Guid id);
  CustomResult UpdateAnnouncement(UpdateAnnouncementRequest data);
  CustomResult AddAnnouncement(AddAnnouncementRequest data);
}